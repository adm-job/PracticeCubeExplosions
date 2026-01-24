using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Explosion _explosion = new();

    [SerializeField] private Raycastre _raycastre;

    [SerializeField] private Vector3 _offset = new Vector3(0, 2f, 0);

    private DivisableObject _divisableObject = new();

    public List<GameObject> GameObgects = new();

    private float _maxClone = 5;

    private void OnEnable()
    {
        _raycastre.ObjectSelected += Copy;
    }

    private void OnDisable()
    {
        _raycastre.ObjectSelected -= Copy;
    }

    private void Start()
    {
        _maxClone = Random.Range(2f, 6f);
    }

    private void Copy(GameObject gameObject)
    {
        if (_divisableObject.Chance())
        {
            for (float i = 0; i < _maxClone; i++)
            {
                GameObject clone = Instantiate(
                    gameObject,
                    gameObject.transform.position + _offset,
                    gameObject.transform.rotation
                    );

                GameObgects.Add(clone);

                clone.name = gameObject.name + "_Copy";
                clone.transform.localScale = new Vector3(clone.transform.localScale.x / 2, clone.transform.localScale.y / 2, clone.transform.localScale.z / 2);

                Renderer renderer = clone.GetComponent<Renderer>();

                if (renderer != null)
                {
                    renderer.material.color = new Color(
                        Random.value,
                        Random.value,
                        Random.value
                        );
                }
            }
        }
        else
        {
            _explosion.Exploded();
            GameObject.Destroy(gameObject);
        }
    }
}
