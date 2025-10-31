using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.position.y < -2)
            GameObject.Destroy(gameObject);
    }
}
