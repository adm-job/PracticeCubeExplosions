using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void lastUpdate()
    {
        if (gameObject.transform.position.y < -2)
            GameObject.Destroy(gameObject);
    }
}
