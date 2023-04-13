using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaShellAttack : MonoBehaviour
{
    [SerializeField] private Cooldown _attackCooldown;

    [SerializeField] private LayerCheck _canMeeleAttack;
    [SerializeField] protected CheckCircleOverlap _checkDamageableProps;
    [SerializeField] private int _meleeDamage;  

    [SerializeField] private LayerCheck _vision;
    [SerializeField] private SpawnComponent _pearlSpawner;

    [SerializeField] private SpawnComponent _destroyedShellSpawner;


    private Animator _animator;
    protected static readonly int MeeleAtatckKey = Animator.StringToHash("meele-attack");
    protected static readonly int RangeAtatckKey = Animator.StringToHash("range-attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
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

    public  void RangeAttack()
    {
        _pearlSpawner.Spawn();
    }

    public void Die()
    {
        _destroyedShellSpawner.Spawn();
    }


}
