using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    void Update()
    {
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
    }
}
