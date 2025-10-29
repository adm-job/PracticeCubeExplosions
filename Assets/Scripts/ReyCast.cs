using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReyCast : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistans = 10f;
    [SerializeField] private float _radius = 0.1f;
    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistans, Color.magenta);

        if(Physics.Raycast(_ray,out hit, Mathf.Infinity))
        {
            Transform objectHit = hit.transform;
            print(objectHit);
        }
    }
}
