using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _radius = 0.1f;
    [SerializeField] private InputReader _mouseInput;

    public event Action<Cube> ObjectSelected;

    private void OnEnable()
    {
        _mouseInput.Clicked += RayCast;
    }

    private void OnDisable()
    {
        _mouseInput.Clicked -= RayCast;
    }

    private void RayCast(Vector3 input)
    {
        Ray ray = _camera.ScreenPointToRay(input);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube _cube))
            {
                ObjectSelected?.Invoke(_cube);
            }
        }
    }
}
