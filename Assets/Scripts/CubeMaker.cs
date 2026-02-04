using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Drawing;

public class CubeMaker : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new(0, 2f, 0);

    private float _maxClone = 5f;
    private float _minClone = 2f;
    private float _maxCubes;
    private float divider = 2f;

    public List<Rigidbody> RigidbodyCubes;
    public event Action<List<Rigidbody>> CubesSpawned;

    private void Start()
    {
        _maxCubes = UnityEngine.Random.Range(_minClone, _maxClone + 1);
    }

    public void Copy(Cube cube)
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
            clone.WriteChanceÑrushing(cube.ÑhanceÑrushing / divider);
            clone.Renderer.material.color = UnityEngine.Random.ColorHSV();

            RigidbodyCubes.Add(clone.Rigidbody);
        }

        CubesSpawned?.Invoke(RigidbodyCubes);

    }

    private void Remove(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
