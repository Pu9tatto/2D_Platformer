using UnityEngine;

public class StarMovement : EnemyMovement
{
    [SerializeField] private ColliderCheck _attackCheck;
    [SerializeField] private Cooldown _timeToAttack;

    private bool _isSpin = false;
    public void IsSpin(bool isSpin) => _isSpin = isSpin;

    protected override void Start()
    {
        base.Start();
    }

    public override void Move()
    {
        if (_isSpin)
        {
            if (_attackCheck.IsTouchingLayer)
            {
                if (_timeToAttack.IsReady())
                {
                    _timeToAttack.Reset();
                    Attack();
                }
            }
        }
        else
        {
            base.Move();
        }
    }
}
