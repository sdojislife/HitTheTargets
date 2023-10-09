using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject _tryAgainText;
    [SerializeField] private TargetSpawner _targetSpawner;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private AudioSource _flyingSound, _throwingSound;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _rotationSpeed;
    private readonly Vector3 _spawnPosition = new Vector3(0, -7.1f, -1);
    private int _clicks = 0;
    private bool _canClick = true;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canClick)
        {
            if(_clicks % 2 != 0)
            {
                Fly();
            }
            else
            {
                Release();
            }
            _animator.SetBool("ReAppear", false);
            _clicks++;
        }
        transform.Rotate(new Vector3(0,_rotationSpeed, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            _targetSpawner.Spawn();
            _scoreUI.UpdateScore();
            GetComponent<BoxCollider>().enabled = false;
            Invoke("ReAppear", 2f);
        }
        if (collision.gameObject.TryGetComponent(out Border border) || collision.gameObject.TryGetComponent(out Ground ground) && _rotationSpeed == 250 || collision.gameObject.TryGetComponent(out Ground ground2) && transform.rotation.eulerAngles.x != 0)
        {
            GameObject tryagain = Instantiate(_tryAgainText);
            Debug.Log(transform.rotation.eulerAngles.x);
        }
    }

    private void Fly()
    {
        _rotationSpeed = 0;
        float angle = transform.rotation.x * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        _rigidbody.AddRelativeForce(direction * 2500, ForceMode.Force);
        _canClick = false;
        _throwingSound.Play();
    }
    private void Release()
    {
        _rigidbody.AddForce(Vector3.up * 600, ForceMode.Force);
        _rotationSpeed = 250;
        _flyingSound.Play();
    }
    public void ReAppear()
    {
        _animator.SetBool("ReAppear", true);
        _rigidbody.Sleep();
        transform.rotation = Quaternion.Euler(0, 90, 90);
        transform.position = _spawnPosition;
        GetComponent<BoxCollider>().enabled = true;
        _canClick = true;
    }

}