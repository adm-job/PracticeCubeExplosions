using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private CubeSpawner _cubeSpawner;
    private List<Rigidbody> _objectRigidbody;

    private void OnEnable()
    {
        _cubeSpawner.OnCubesSpawned += GetExplodableObject;
    }

    private void OnDisable()
    {
        _cubeSpawner.OnCubesSpawned += GetExplodableObject;
    }

    public void Exploded()
    {
        foreach (var explosionObject in _objectRigidbody)
        {
            explosionObject.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }
    
    private void GetExplodableObject(List<GameObject> gameObjects)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var gameObject in gameObjects)
        {
            _objectRigidbody.Add(gameObject.GetComponent<Rigidbody>());
        }
    }
}
