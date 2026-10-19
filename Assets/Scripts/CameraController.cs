using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minPitch = -90f;
    [SerializeField] private float _maxPitch = 90f;

    private float _pitch = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RorateCamera(Vector2 mouseDelta, float sensitivity)
    {
        _pitch -= mouseDelta.y * sensitivity;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        transform.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }
}
