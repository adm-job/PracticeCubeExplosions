using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class ReyCast : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private Vector3 _offset = new Vector3(2f,0,0);
    [SerializeField] private float _maxDistans = 10f;
    [SerializeField] private float _radius = 0.1f;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;


        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistans, Color.red, 1f);

            GameObject objectHit = hit.collider.gameObject;
            print(objectHit.name);

            for (int i = 0; i < 3; i++)
            {
                GameObject clone = Instantiate(
                    objectHit,
                    objectHit.transform.position + _offset,
                    objectHit.transform.rotation
                    );
                clone.name = objectHit.name + "_Copy";
            }
        }
    }
}
