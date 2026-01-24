using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Cube cube;

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
    //to do здесь нужны правки что бы получить созданные кубы и раскидать только их
    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        cube.ReturnClon();
        cubes = cube.ReturnClon();

        //List<Rigidbody> explosionObjects = new ();

        foreach (var hit in hits)
        {
            if(hit.attachedRigidbody  != null)
            {
                explosionObjects.Add(hit.attachedRigidbody);
            }
        }
        return explosionObjects;
    }
}
