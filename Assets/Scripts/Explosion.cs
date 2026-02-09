using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    private float _explosionRadiusNormal;
    private float _explosionForceNormal;

    private void Awake()
    {
        _explosionRadiusNormal = _explosionRadius;
        _explosionForceNormal = _explosionForce;
    }

    public void Exploded(List<Rigidbody> cubeRigidbody, Vector3 pointExplosion)
    {
        foreach (var explosionCubes in cubeRigidbody)
        {
            explosionCubes.AddExplosionForce(_explosionForce, pointExplosion, _explosionRadius);
        }

        ResetExplosionRadius();
    }

    public void ExplodedAll(Vector3 pointExplosion, float radiusMultiplier)
    {
        Collider[] hits = Physics.OverlapSphere(pointExplosion, _explosionRadius);

        List<Rigidbody> allCubes = new();

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null && hit.GetComponent<Cube>())
            {
                allCubes.Add(hit.attachedRigidbody);
            }
        }

        ChangingExplosionRadius(radiusMultiplier);
        Exploded(allCubes, pointExplosion);
    }

    private void ChangingExplosionRadius(float radiusMultiplier)
    {
        _explosionRadius /= radiusMultiplier;
        _explosionForce /= radiusMultiplier;
    }

    private void ResetExplosionRadius()
    {
        _explosionRadius = _explosionRadiusNormal;
        _explosionForce = _explosionForceNormal;
    }
}
