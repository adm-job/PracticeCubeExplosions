using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private int _mouseButton = 0;
    public event Action Click;

    public void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
            Click?.Invoke();
    }
}
