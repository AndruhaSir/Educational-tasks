using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 1f;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 direction = forward * InputManager.YAxis + right * InputManager.XAxis;

        direction.Normalize();

        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}
