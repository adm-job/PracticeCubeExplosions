using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private CubeMaker _cubeSpawner =new ();

    private void OnEnable()
    {
        _cubeSpawner.CubesSpawned += Exploded;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubesSpawned += Exploded;
    }

    public void Exploded(List<Rigidbody> cubeRigidbody)
    {
        foreach (var explosionCubes in cubeRigidbody)
        {
            explosionCubes.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }
}
