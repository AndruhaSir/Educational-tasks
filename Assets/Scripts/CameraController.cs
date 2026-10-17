using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 0.15f;
    [SerializeField] private float _minPitch = -90f;
    [SerializeField] private float _maxPitch = 90f;

    private float _pitch = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RorateCameraAndParent();
    }

    private void RorateCameraAndParent()
    {
        float rotationY = InputManager.MouseDelta.x * _sensitivity;
        transform.parent.Rotate(0, rotationY, 0);

        _pitch -= InputManager.MouseDelta.y * _sensitivity;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        transform.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }
}
