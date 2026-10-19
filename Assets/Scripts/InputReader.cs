using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public float XKeyboardAxis { get; private set; }
    public float YKeyboardAxis { get; private set; }
    public Vector2 MouseDelta { get; private set; }

    public event Action InteractionButtonPressed;

    private void Update()
    {
        if (Keyboard.current != null)
        {
            UpdateXAxis();
            UpdateZAxis();
        }

        if (Mouse.current != null)
        {
            UpdateMouseDelta();

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                InteractionButtonPressed?.Invoke();
            }
        }
    }

    private void UpdateXAxis()
    {
        XKeyboardAxis = 0f;

        if (Keyboard.current.dKey.isPressed)
        {
            XKeyboardAxis = 1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            XKeyboardAxis = -1f;
        }
    }

    private void UpdateZAxis()
    {
        YKeyboardAxis = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            YKeyboardAxis = 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            YKeyboardAxis = -1f;
        }
    }

    private void UpdateMouseDelta()
    {
        MouseDelta = Mouse.current.delta.ReadValue();
    }
}