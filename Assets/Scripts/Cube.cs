using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private float _chance—rushing = 1.0f;
    
    public MeshRenderer Renderer { get;private set; }
    public Rigidbody Rigidbody { get; private set; }

    public float —hance—rushing { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
        Debug.Log("ÿ¿Õ— = " + _chance—rushing);
        —hance—rushing = _chance—rushing;
    }

    public void WriteChance—rushing(float newChance)
    {
        _chance—rushing = newChance;
    }
}
