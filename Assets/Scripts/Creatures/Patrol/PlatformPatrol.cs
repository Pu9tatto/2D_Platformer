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

            _movement.SetDirection(direction);
            _animation.SetDirectionX(1);
            yield return new WaitForFixedUpdate();
            if (!_endPlatformChecker.CheckTouchingLayer())
            {
                direction*=-1;
            } else if (_obstackleChecker.CheckTouchingLayer())
            {
                direction *= -1;
            }

        }
    }
}
