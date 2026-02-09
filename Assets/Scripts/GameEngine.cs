using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] private Explosion Explosion;
    [SerializeField] private CubeMaker CubeMaker;
    [SerializeField] private Raycaster Raycaster;
    [SerializeField] private InputReader inputReader;

    private void OnEnable()
    {
        inputReader.Clicked += InputMouse;
        Raycaster.ObjectSelected += CopyCube;
        CubeMaker.CubesSpawned += Exploded;
    }

    private void OnDisable()
    {
        inputReader.Clicked -= InputMouse;
        Raycaster.ObjectSelected -= CopyCube;
        CubeMaker.CubesSpawned -= Exploded;
    }

    private void InputMouse(Vector3 input)
    {
        Raycaster.RayCast(input);
    }

    private void CopyCube(Cube cube)
    {
        if (cube.ChanceCrushing >= UnityEngine.Random.value)
        {
            CubeMaker.Copy(cube);
        }
        else
        {
            Explosion.ExplodedAll(cube.transform, cube.ChanceCrushing);
        }

        CubeMaker.Remove(cube);
    }

    private void Exploded(List<Rigidbody> rigidbodies)
    {
        Explosion.Exploded(rigidbodies);
    }
}
