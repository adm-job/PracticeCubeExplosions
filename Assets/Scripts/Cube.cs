using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private RandomCountChance randomChance = new();
    public MeshRenderer MeshRenderer { get; set; }
    public Rigidbody Rigidbody { get; set; }


    public bool ReturnChance()
    {
        bool chance = randomChance.CreateChance();

        return chance;
    }
}
