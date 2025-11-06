using UnityEngine;
using UnityEngine.Events;

public class Raycastre : MonoBehaviour
{
    public event UnityAction <GameObject> ObjectSelected;  

    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private float _radius = 0.1f;
    [SerializeField] private MouseInput _mouseInput;

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

            GameObject.Destroy(objectHit);
        }
    }
}
