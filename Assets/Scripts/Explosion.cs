using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    float _explosionRadiusNormal;

    private void Awake()
    {
        _explosionRadiusNormal = _explosionRadius;
    }

    public void Exploded(List<Rigidbody> cubeRigidbody)
    {
        foreach (var explosionCubes in cubeRigidbody)
        {
            Debug.Log("Радиус = " + _explosionRadius);
            explosionCubes.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        ResetExplosionRadius();
    }

    public void ExplodedAll(Transform transform, float radiusMultiplier)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> allCubes = new();

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null && hit.GetComponent<Cube>())
            {
                allCubes.Add(hit.attachedRigidbody);
            }
        }

        ChangingExplosionRadius(radiusMultiplier);
        Exploded(allCubes);
    }

    private void ChangingExplosionRadius(float radiusMultiplier)
    {
        _explosionRadius /= radiusMultiplier;
    }

    private void ResetExplosionRadius()
    {
        _explosionRadius = _explosionRadiusNormal;
    }
}
