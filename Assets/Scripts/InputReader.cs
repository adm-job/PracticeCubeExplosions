using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    public event Action Click;
    private int MouseButton = 0;

    public void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
            Click?.Invoke();
    }
}
