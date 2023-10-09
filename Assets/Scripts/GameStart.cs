using UnityEngine;
using UnityEngine.Events;
public class GameStart : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGameStarted;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _onGameStarted.Invoke();
            Destroy(gameObject);
        }
    }
}
