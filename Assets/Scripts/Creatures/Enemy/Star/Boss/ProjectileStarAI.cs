using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileStarAI: StarAI
    {
    [SerializeField] private int _healthOnEnable;
    [SerializeField] private UnityEvent _actionAfterDie;
    private Transform _target;
    private HealthComponent _health;

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<HealthComponent>();
        _target = FindObjectOfType<Hero>().transform;
    }

    protected override void OnEnable()
    {
        _isDie = false;
        _isPrepare = false;
        _isSpin = false;
        _health.SetHealth(_healthOnEnable);

        if(_target != null)
            _direction = (_target.transform.position - transform.position).normalized;

        StartState(Co_PrepareToSpin());
    }
    
    public override void OnDie()
    {
        base.OnDie();
        _actionAfterDie?.Invoke();
        StartCoroutine(Co_DisableGO());
    }

    private IEnumerator Co_DisableGO()
    {
        yield return new WaitForFixedUpdate();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

