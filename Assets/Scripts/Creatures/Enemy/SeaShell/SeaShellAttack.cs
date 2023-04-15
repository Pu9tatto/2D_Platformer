using UnityEngine;

public class SeaShellAttack : RangeTrapAI
{
    [SerializeField] private ColliderCheck _canMeeleAttack;
    [SerializeField] private CheckCircleOverlap _checkDamageableProps;
    [SerializeField] private int _meleeDamage;  

    protected static readonly int MeeleAtatckKey = Animator.StringToHash("meele-attack");

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        if (!_attackCooldown.IsReady()) return;

        _attackCooldown.Reset();

        if (_canMeeleAttack.IsTouchingLayer)
        {
            _animator.SetTrigger(MeeleAtatckKey);
            return;
        }

        if(_vision.IsTouchingLayer)
        {
            _animator.SetTrigger(RangeAtatckKey);
        }
    }

    public void MeeleAttack()
    {
        var list = _checkDamageableProps.Check();

        foreach (var props in list)
        {
            if (props.TryGetComponent(out HealthComponent attackTarget))
            {
                attackTarget.ChangeHealth(-_meleeDamage);
            }
        }
    }

    public override void RangeAttack()
    {
        base.RangeAttack();
    }

    public override void Die()
    {
        base.Die();
    }


}
