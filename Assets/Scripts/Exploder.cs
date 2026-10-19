using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _explosionForce = 5f;
    [SerializeField, Min(0.1f)] private float _explosionRadius = 3f;

    public void Explode(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);
        HashSet<Rigidbody> rigidbodies = new HashSet<Rigidbody>();

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;

            if (rb == null || rb.isKinematic || !rigidbodies.Add(rb))
            {
                continue;
            }

            rb.AddExplosionForce(_explosionForce, position, _explosionRadius, 0f, ForceMode.Impulse);
        }
    }
}
