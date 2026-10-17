using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    private ButtonControl _interactionButton;

    public static float XAxis { get; private set; }
    public static float YAxis { get; private set; }
    public static Vector2 MouseDelta { get; private set; }

    public static event Action InteractionButtonPressed;

    private void Start()
    {
        _interactionButton = Mouse.current.leftButton;
    }

    void Update()
    {
        UpdateZAxis();
        UpdateXAxis();
        UpdateMouseDelta();
        CheckInterectionButtonClick();
    }

    private void UpdateXAxis()
    {
        XAxis = 0;

        if (Keyboard.current.dKey.isPressed) XAxis = 1;
        if (Keyboard.current.aKey.isPressed) XAxis = -1;
    }
    private void UpdateZAxis()
    {
        YAxis = 0;

        if (Keyboard.current.wKey.isPressed) YAxis = 1;
        if (Keyboard.current.sKey.isPressed) YAxis = -1;
    }

    private void UpdateMouseDelta()
    {
        MouseDelta = Mouse.current.delta.ReadValue();
    }

    private void CheckInterectionButtonClick()
    {
        if (_interactionButton.wasPressedThisFrame) InteractionButtonPressed?.Invoke();
    }
}
