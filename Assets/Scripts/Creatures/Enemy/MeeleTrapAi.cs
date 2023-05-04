using UnityEngine;

[RequireComponent (typeof(Animator))]
public class MeeleTrapAi : MonoBehaviour
{
    [SerializeField] private Cooldown _attackCooldown;
    [SerializeField] private ColliderCheck _canMeeleAttack;
    [SerializeField] private CheckCircleOverlap _checkDamageableProps;
    [SerializeField] private PoolObjectSpawnComponent _attackParticle;
    [SerializeField] private int _meleeDamage;

    private Animator _animator;

    protected static readonly int AttackKey = Animator.StringToHash("base-attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_canMeeleAttack.IsTouchingLayer)
        {
            if (!_attackCooldown.IsReady()) return;

            _attackCooldown.Reset();
            _animator.SetTrigger(AttackKey);
        }
    }
    public void Attack()
    {
        var list = _checkDamageableProps.Check();

        foreach (var props in list)
        {
            if (props.TryGetComponent(out HealthComponent attackTarget))
            {
                _attackParticle.Spawn();
                attackTarget.ChangeHealth(-_meleeDamage);
            }
        }
    }
}
