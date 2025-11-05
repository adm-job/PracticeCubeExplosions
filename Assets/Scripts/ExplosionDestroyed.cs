using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyed : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnDestroy()
    {
        Exploded();
    }

    public void Exploded()
    {
        foreach (var explosionObject in GetExplodableObject())
        {
            explosionObject.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> ExplosionObjects = new ();

        foreach (var hit in hits)
        {
            if(hit.attachedRigidbody  != null)
            {
                ExplosionObjects.Add(hit.attachedRigidbody);
            }
        }
        return ExplosionObjects;
    }
}
