using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputReader _inputReader;

    private int _currentScore = 0;
    private int _amountIncrease = 1;
    
    private Coroutine _counterCoroutine;
    private bool _isRunning = false;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _inputReader.ButtonPressed += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputReader.ButtonPressed -= ToggleCounter;
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
        if (_counterCoroutine != null)
        {
            return;
        }

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
            _currentScore += _amountIncrease;
            ScoreChanged?.Invoke(_currentScore);

            yield return wait;
        }
    }
}