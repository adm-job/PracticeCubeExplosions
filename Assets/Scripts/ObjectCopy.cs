using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCopy : MonoBehaviour
{
    [SerializeField] private ExplosionDestroyed _destroy = new ();

    [SerializeField] private Raycastre _rayCast;

    [SerializeField] private Vector3 _offset = new Vector3(0, 2f, 0);

    private ChanceCopy _copyChance = new();

    private float _maxClone = 5;

    private void OnEnable()
    {
        _rayCast.ObjectSelected += Copy;
    }

    private void OnDisable()
    {
        _rayCast.ObjectSelected -= Copy;
    }

    private void Start()
    {
        _maxClone = Random.Range(2f, 6f);
    }

    void Copy(GameObject gameObject)
    {
        if (_copyChance.Chance())
        {
            for (float i = 0; i < _maxClone; i++)
            {
                GameObject clone = Instantiate(
                    gameObject,
                    gameObject.transform.position + _offset,
                    gameObject.transform.rotation
                    );

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
            _destroy.Exploded();
            GameObject.Destroy(gameObject);
        }
    }
}
