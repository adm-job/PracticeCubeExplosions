using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class RayCast : MonoBehaviour
{
    public event UnityAction <GameObject> OnRaycastHit;  

    [SerializeField] private Camera _camera;
    //[SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private float _radius = 0.1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            GameObject objectHit = hit.collider.gameObject;

            OnRaycastHit?.Invoke(objectHit);

            GameObject.Destroy(objectHit);
        }
    }
}
