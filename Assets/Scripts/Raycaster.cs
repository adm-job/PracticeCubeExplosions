using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _radius = 0.1f;
    [SerializeField] private InputReader _mouseInput;

    public event Action<GameObject> ObjectSelected;

    private void OnEnable()
    {
        _mouseInput.Click += RayCast;
    }

    private void OnDisable()
    {
        _mouseInput.Click -= RayCast;
    }

    private void RayCast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject objectHit = hit.collider.gameObject;

            ObjectSelected?.Invoke(objectHit);

        
            if (hit.collider.TryGetComponent<Cube>(out var cube))
        {
            ObjectSelected?.Invoke(cube);
        }
        }
    }
}
