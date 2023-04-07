using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrartExplosionForceComponent : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _force;
    [SerializeField] private GameObject[] _objectsForExplosion;


    private void OnEnable()
    {
        foreach (var obj in _objectsForExplosion)
        {
            if(obj.TryGetComponent(out Rigidbody2D rb))
            {
                var v2 = obj.transform.localEulerAngles;
                rb.AddForceAtPosition(Vector2.up * _force, _center.position);
            }
        }
    }
}
