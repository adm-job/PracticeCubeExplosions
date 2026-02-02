using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private RandomCountChance _randomChance;
    public MeshRenderer MeshRenderer { get; set; }
    public Rigidbody Rigidbody { get; set; }


    public bool ReturnChance()
    {
        bool chance = _randomChance.CreateChance();

        return chance;
    }
}
