using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _value;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateScore()
    {
        _value++;
        _text.text = _value.ToString();
    }
}
