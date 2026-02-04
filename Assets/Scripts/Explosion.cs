using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Exploded(List<Rigidbody> cubeRigidbody)
    {
        foreach (var explosionCubes in cubeRigidbody)
        {
            explosionCubes.AddExplosionForce(_explosionForce, transform.position,_explosionRadius);
        }
    }
}
