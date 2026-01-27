using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private CubeMaker _cubeSpawner;
    private List<Rigidbody> _cubeRigidbody;

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
        foreach (var explosionObject in _cubeRigidbody)
        {
            explosionObject.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }
    
    private void GetExplodableObject(List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            _cubeRigidbody.Add(gameObject.GetComponent<Rigidbody>());
        }
    }
}
