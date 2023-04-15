using UnityEngine;

public class RangeTrapAI : MonoBehaviour
{
    [SerializeField] protected Cooldown _attackCooldown;

    [SerializeField] protected ColliderCheck _vision;
    [SerializeField] protected SpawnComponent _projectileSpawner;

    [SerializeField] protected SpawnComponent _destroyedMobSpawner;


    protected Animator _animator;
    protected static readonly int RangeAtatckKey = Animator.StringToHash("range-attack");

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

        if (_vision.IsTouchingLayer)
        {
            if (!_attackCooldown.IsReady()) return;

            _attackCooldown.Reset();
            _animator.SetTrigger(RangeAtatckKey);
        }
    }

    public virtual void RangeAttack()
    {
        _projectileSpawner.Spawn();
    }

    public virtual void Die()
    {
        _destroyedMobSpawner.Spawn();
    }
}
