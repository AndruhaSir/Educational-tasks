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
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody == null || rigidbody.isKinematic || !rigidbodies.Add(rigidbody))
            {
                continue;
            }

            rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius, 0f, ForceMode.Impulse);
        }
    }

    public void Explode(Vector3 position, List<GameObject> gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == null)
            {
                continue;
            }

            Rigidbody rigidbodyComponent = gameObject.GetComponent<Rigidbody>();

            if (rigidbodyComponent == null || rigidbodyComponent.isKinematic)
            {
                continue;
            }

            rigidbodyComponent.AddExplosionForce(_explosionForce, position, _explosionRadius, 0f, ForceMode.Impulse);
        }
    }
}
