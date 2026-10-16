using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputReader : MonoBehaviour
{
    private ButtonControl _observedKey;

    public event Action ButtonPressed;

    private void Start()
    {
        _observedKey = Mouse.current.leftButton;
    }

    private void Update()
    {
        if (_observedKey.wasPressedThisFrame)
        {
            ButtonPressed?.Invoke();
        }
    }
}
