using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private int _mouseButton = 0;
    public event Action<Vector3> Clicked;

    public void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
            Clicked?.Invoke(Input.mousePosition);
    }
}
