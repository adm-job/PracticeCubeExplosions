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

    private void OnEnable()
    {
        Raycaster.ObjectSelected += Test;
    }

    private void OnDisable()
    {
        Raycaster.ObjectSelected += Test;
    }

    public void Test(Cube cube)
    { 
        if (cube.ÑhanceÑrushing >= UnityEngine.Random.value)
        {
            CubeMaker.Copy(cube);
        }
        else
        {
            Exception.
        }
    }
}
