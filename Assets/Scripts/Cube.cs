using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private float _chanceCrushing = 1.0f;
    
    public MeshRenderer Renderer { get;private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float ChanceCrushing { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
        ChanceCrushing = _chanceCrushing;
    }

    public void WriteChanceCrushing(float newChance)
    {
        _chanceCrushing = newChance;
        ChanceCrushing = newChance;
    }
}
