using UnityEngine;

public class RangeTrapAI : MonoBehaviour
{
    [SerializeField] protected Cooldown _attackCooldown;

    [SerializeField] protected ColliderCheck _vision;
    [SerializeField] protected SpawnComponent _projectileSpawner;

    [SerializeField] protected SpawnComponent _destroyedMobSpawner;


    protected Animator _animator;
    protected static readonly int BaseAtatckKey = Animator.StringToHash("base-attack");

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (!_attackCooldown.IsReady()) return;

        _attackCooldown.Reset();

        if (_vision.IsTouchingLayer)
        {
            _animator.SetTrigger(BaseAtatckKey);
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
