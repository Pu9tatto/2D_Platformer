using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : Patrol
{
    [SerializeField] private LayerCheck _endPlatformChecker;
    [SerializeField] private LayerCheck _obstackleChecker;

    private CreaturesMovement _movement;
    private CreatureAnimation _animation;

    private Vector2 direction = Vector2.right;

    private void Awake()
    {
        _movement = GetComponent<CreaturesMovement>();
        _animation = GetComponent<CreatureAnimation>();
    }

    public override IEnumerator DoPatrol()
    {
        while (enabled)
        {

            if (!_endPlatformChecker.IsTouchingLayer)
            {
                direction *= -1;
            }
            else if (_obstackleChecker.IsTouchingLayer)
            {
                direction *= -1;
            }

            _movement.SetDirection(direction);
            //_animation.SetDirection(1);
            _animation.DoMove();
            yield return null;
        }
    }
}
