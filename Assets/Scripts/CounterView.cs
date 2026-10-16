using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.OnScoreChanged += ChangeScoreText;
    }

    private void OnDisable()
    {
        _counter.OnScoreChanged -= ChangeScoreText;
    }

    private void ChangeScoreText(int value)
    {
        _textMeshPro.text = value.ToString();
    }
}
