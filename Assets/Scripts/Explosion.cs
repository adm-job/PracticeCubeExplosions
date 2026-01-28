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
        _cubeSpawner.OnCubesSpawned += Exploded;
    }

    private void OnDisable()
    {
        _cubeSpawner.OnCubesSpawned += Exploded;
    }

    public void Exploded(List<Rigidbody> rigidbodies)
    {
        foreach (var explosionCubes in rigidbodies)
        {
            explosionCubes.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }
    
    //private void GetExplodableObject(List<Cube> cubes)
    //{
    //    foreach (var cube in cubes)
    //    {
    //        _cubeRigidbody.Add(cube.GetComponent<Rigidbody>());
    //    }
    //}
}
