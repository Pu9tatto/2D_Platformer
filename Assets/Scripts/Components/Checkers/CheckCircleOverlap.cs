using System.Collections.Generic;
using UnityEngine;

public class CheckCircleOverlap : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    private readonly Collider2D[] _collidedResult = new Collider2D[5];

    public List<GameObject> Check()
    {
        var result = new List<GameObject>();

        var size = Physics2D.OverlapCircleNonAlloc(
            transform.position,
            _radius,
            _collidedResult,
            _layer);

        for (int i = 0; i < size; i++)
        {
            result.Add(_collidedResult[i].gameObject);
        }

        return result;
    }
}
