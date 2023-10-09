using UnityEngine;
using UnityEngine.SceneManagement;
public class TryAgain : MonoBehaviour
{
    private void Start()
    {
        transform.parent = FindObjectOfType<Canvas>().transform;
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -190, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}