using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _radius = 0.1f;

    public event Action<Cube> ObjectSelected;

    public void RayCast(Vector3 input)
    {
        Ray ray = _camera.ScreenPointToRay(input);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                ObjectSelected?.Invoke(cube);
            }
        }
    }
}
