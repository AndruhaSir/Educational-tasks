using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private int _currentScore = 0;
    private int _amountIncrease = 1;
    private TextMeshProUGUI _textMeshPro;
    private ButtonControl _keyToStartCounter;
    private Coroutine _counterCoroutine;
    private bool _isRunning = false;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _keyToStartCounter = Mouse.current.leftButton;
    }

    private void Update()
    {
        if (_keyToStartCounter.wasPressedThisFrame)
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        if (_isRunning)
        {
            StopCounter();
        }
        else
        {
            StartCounterCoroutine();
        }
    }

    private void StartCounterCoroutine()
    {
        _isRunning = true;
        _counterCoroutine = StartCoroutine(StartCounter());
    }

    private void StopCounter()
    {
        _isRunning = false;

        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
    }

    private IEnumerator StartCounter()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _textMeshPro.text = _currentScore.ToString();
            _currentScore += _amountIncrease;

            yield return wait;
        }
    }
}