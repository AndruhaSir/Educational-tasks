using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{

    public void Explode(Vector3 position, float explosionForce, float explosionRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);
        HashSet<Rigidbody> rigidbodies = new HashSet<Rigidbody>();

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody == null || rigidbody.isKinematic || !rigidbodies.Add(rigidbody))
            {
                continue;
            }

            rigidbody.AddExplosionForce(explosionForce, position, explosionRadius, 0f, ForceMode.Impulse);
        }
    }
}
