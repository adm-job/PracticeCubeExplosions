using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    public event UnityAction Click;
    private int MouseButton = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
            Click?.Invoke();
    }
}
