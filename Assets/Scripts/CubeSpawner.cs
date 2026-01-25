using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Explosion _explosion = new();

    [SerializeField] private Raycaster _raycastre;

    [SerializeField] private Vector3 _offset = new Vector3(0, 2f, 0);

    private Cube _divisableObject = new();

    public List<GameObject> SpawnedCubes = new();
    public event Action<List<GameObject>> OnCubesSpawned;

    private float _maxClone = 5;

    private void OnEnable()
    {
        _raycastre.ObjectSelected += Copy;
    }

    private void OnDisable()
    {
        _raycastre.ObjectSelected -= Copy;
    }

    private void Start()
    {
        _maxClone = UnityEngine.Random.Range(2f, 6f);
    }

    private void Copy(GameObject gameObject)
    {
        if (_divisableObject.CreateChance())
        {
            for (float i = 0; i < _maxClone; i++)
            {
                GameObject clone = Instantiate(
                    gameObject,
                    gameObject.transform.position + _offset,
                    gameObject.transform.rotation
                    );

                clone.name = gameObject.name + "_Copy";
                clone.transform.localScale = new Vector3(clone.transform.localScale.x / 2, clone.transform.localScale.y / 2, clone.transform.localScale.z / 2);

                Renderer renderer = clone.GetComponent<Renderer>();

                if (renderer != null)
                {
                    renderer.material.color = new Color(
                        UnityEngine.Random.value,
                        UnityEngine.Random.value,
                        UnityEngine.Random.value
                        );
                }

                SpawnedCubes.Add(clone);
            }

            OnCubesSpawned?.Invoke(SpawnedCubes);
            GameObject.Destroy(gameObject);
            _explosion.Exploded();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    public List<GameObject> ReturnClon()
    {
        return SpawnedCubes;
    }
}
