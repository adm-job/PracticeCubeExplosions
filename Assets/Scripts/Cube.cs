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
    private float _chance = 1;
    
    public MeshRenderer Renderer { get;private set; }
    public Rigidbody Rigidbody { get; private set; }

    public float Chance { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
        Chance = _chance;
    }

    public bool ReturnChance()
    {
        return _randomChance.CreateChance(_chance);
    }

    public void ReadNewChance(float newChance)
    {
        _chance = newChance;
    }
}
