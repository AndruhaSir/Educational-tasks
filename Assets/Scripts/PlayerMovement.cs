using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private float _sensitivity = 0.15f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_inputReader == null)
        {
            _inputReader = GetComponent<InputReader>();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        _cameraController.RorateCamera(_inputReader.MouseDelta, _sensitivity);
        RotatePlayerWithMouse();
    }

    private void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 direction = forward * _inputReader.YKeyboardAxis + right * _inputReader.XKeyboardAxis;

        direction.Normalize();

        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }

    private void RotatePlayerWithMouse()
    {
        float rotationY = _inputReader.MouseDelta.x * _sensitivity;
        gameObject.transform.Rotate(0, rotationY, 0);
    }
}
