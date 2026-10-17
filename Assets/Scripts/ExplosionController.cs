using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosionController : MonoBehaviour
{
    public static void Explode(Vector3 position, float explosionForce, float explosionRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);
        HashSet<Rigidbody> rigidbodies = new HashSet<Rigidbody>();

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;

            if (rb == null || rb.isKinematic || !rigidbodies.Add(rb))
                continue;

            rb.AddExplosionForce(
                explosionForce,
                position,
                explosionRadius,
                0f,
                ForceMode.Impulse
            );
        }
    }
}
