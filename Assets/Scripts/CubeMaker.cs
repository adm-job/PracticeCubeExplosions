using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    [SerializeField] private Raycaster _raycastre;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2f, 0);

    private RandomCountChance _divisibleObject = new();
    private float _maxClone = 5f;
    private float _minClone = 2f;
    private float _maxCubes;

    public List<Rigidbody> SpawnedCubes;
    public event Action<List<Rigidbody>> OnCubesSpawned;

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
        _maxCubes = UnityEngine.Random.Range(_minClone, _maxClone + 1);
    }

    private void Copy(Cube cube)
    {
        if (_divisibleObject.CreateChance())
        {
            for (float i = 0; i < _maxCubes; i++)
            {
                Cube clone = Instantiate(
                    cube,
                    cube.transform.position + _offset,
                    cube.transform.rotation
                    );

                clone.name = cube.name;
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

                SpawnedCubes.Add(clone.GetComponent<Rigidbody>());
            }

            OnCubesSpawned?.Invoke(SpawnedCubes);
            Destroy(cube.gameObject);
        }
        else
        {
            Destroy(cube.gameObject);
        }
    }
}
