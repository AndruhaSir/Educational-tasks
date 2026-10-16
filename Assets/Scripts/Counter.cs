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

    public event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        _inputReader.OnPressButton += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputReader.OnPressButton -= ToggleCounter;   // ← отписка
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
            _currentScore += _amountIncrease;
            OnScoreChanged?.Invoke(_currentScore);

            yield return wait;
        }
    }
}