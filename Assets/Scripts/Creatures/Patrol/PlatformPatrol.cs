using System.Collections;
using UnityEngine;

public class PlatformPatrol : Patrol
{
    [SerializeField] private LayerCheck _endPlatformChecker;
    [SerializeField] private LayerCheck _obstackleChecker;

    private CreaturesMovement _movement;
    private CreatureAnimation _animation;

    private Vector2 _direction = Vector2.right;

    private void Awake()
    {
        _movement = GetComponent<CreaturesMovement>();
        _animation = GetComponent<CreatureAnimation>();
    }

    public override IEnumerator DoPatrol()
    {
        while (enabled)
        {
            if ( _animation.IsGrounded())
            {
                if (!_endPlatformChecker.IsTouchingLayer)
                {
                    _direction *= -1;
                }
                else if (_obstackleChecker.IsTouchingLayer)
                {
                    _direction *= -1;
                }

                _movement.SetDirection(_direction);
                _animation.DoMove();
            }
            else
            {
                _animation.SetDirection(Vector2.zero);
            }

            yield return null;
        }
    }
}
