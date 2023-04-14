
using System.Collections.Generic;
using UnityEngine;

public class SpawnInCircle : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _count;

    [SerializeField] private GameObject _prefab;

    private float _sectorRad;

    private void Awake()
    {
        _sectorRad = Mathf.PI * 2/ _count;
    }

    private void Start()
    {
        Vector2 center = transform.position;
        for (int i = 0; i < _count; i++)
        {
            var startPoint = center;
            startPoint.x +=  _radius * Mathf.Cos(_sectorRad * i);
            startPoint.y += _radius * Mathf.Sin(_sectorRad * i);
            Instantiate(_prefab, startPoint, Quaternion.identity, transform);
        }
    }
}
