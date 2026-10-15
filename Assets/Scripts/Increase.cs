using UnityEngine;

public class Increase : MonoBehaviour
{
    [SerializeField] private float _amountIncrease;
    void Update()
    {
        transform.localScale += Vector3.one * _amountIncrease * Time.deltaTime;
    }
}
