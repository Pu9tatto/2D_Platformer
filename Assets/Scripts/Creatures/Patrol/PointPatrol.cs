using System.Collections;
using UnityEngine;

public class PointPatrol : Patrol
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _sqrTrashold;

    private CreaturesMovement _movement;
    private CreatureAnimation _animation;

    private int _destinationPointIndex;

    private void Awake()
    {
        _movement = GetComponent<CreaturesMovement>();
        _animation = GetComponent<CreatureAnimation>();
    }
    public override IEnumerator DoPatrol()
    {
        while (enabled)
        {
            if (IsOnPoint())
            {
                _destinationPointIndex = (int) Mathf.Repeat(_destinationPointIndex+1,_points.Length);
            }

            Vector2 direction = (_points[_destinationPointIndex].position - transform.position).normalized;
            _movement.SetDirection(direction);
            _animation.SetDirection(direction);

            yield return null;
        }
    }

    private bool IsOnPoint()
    {
        return (_points[_destinationPointIndex].position - transform.position).sqrMagnitude < _sqrTrashold;
    }

}
