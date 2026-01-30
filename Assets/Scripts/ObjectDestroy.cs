using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    private float _minHeight = -2;
    private void Update()
    {

        if (gameObject.transform.position.y < _minHeight)
            GameObject.Destroy(gameObject);
    }
}
