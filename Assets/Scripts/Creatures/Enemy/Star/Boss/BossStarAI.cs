using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossStarAI : MonoBehaviour
{
    [SerializeField] private LayerCheck _obstackleChecker;

    [SerializeField] private float _speedSpin;
    [SerializeField] private Cooldown _spinDelay;
    [SerializeField] private float _timeToPrepareForSpin = 1f;

    [SerializeField] private PoolObjectSpawnComponent _starSpawner;
    [SerializeField] private float _timeBetweenThrow = 1f;
    [SerializeField] private Cooldown _patrolDuration;
    [SerializeField] private BossPhase[] _bossPhases;

    private int _ratePatrol;
    private int _rateSpinToTarget;
    private int _rateThrow;
    private int _throwCount = 3;
    private int _currentPhase = 0;

    private Coroutine _current;
    private StarMovement _movement;
    private StarAnimation _animation;
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;
    private Transform _target;
    private Vector3 _defaultScale;

    private Vector2 _patrolDirection = Vector2.right;

    private int _rate => Mathf.Max(_ratePatrol, _rateSpinToTarget, _rateThrow);

    public BossPhase[] BossPhases => _bossPhases;
    public void SetThrowCount(int count) => _throwCount = count;

    private void Awake()
    {
        _defaultScale = transform.localScale;
        _movement = GetComponent<StarMovement>();
        _animation = GetComponent<StarAnimation>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _target = FindObjectOfType<Hero>().transform;
        SwitchPhase(_currentPhase);
        StartRandowmAction();
    }

    public void SwitchPhase(int phase)
    {
        _ratePatrol = _bossPhases[phase].RatePatrol;
        _rateSpinToTarget = _bossPhases[phase].RateSpinToTarget;
        _rateThrow = _bossPhases[phase].RateThrow;
        _throwCount = _bossPhases[phase].ThrowCount;
    }

    private IEnumerator Co_ThrowStar(int count)
    {
        while (count > 0 && _starSpawner.FreeObjectsInPool() > 0)
        {
            LookAtTarget();
            _animation.SetThrow();
            count--;
            yield return new WaitForSeconds(_timeBetweenThrow);
        }
        StartRandowmAction();
    }

    private IEnumerator Co_PatrolAttack()
    {
        _patrolDuration.Reset();
        transform.localScale = _defaultScale;
        while (!_patrolDuration.IsReady())
        {
            if (_animation.IsGrounded())
            {
                if (_obstackleChecker.IsTouchingLayer)
                {
                    _patrolDirection *= -1;
                }

                _animation.DoMove();
            }
            _movement.SetDirection(_patrolDirection);

            yield return null;
        }
        StartRandowmAction();
    }

    private IEnumerator Co_PrepareToSpin()
    {
        LookAtTarget();
        _animation.SetPrepare(true);
        yield return new WaitForSeconds(_timeToPrepareForSpin);
        _animation.SetPrepare(false);

        StartState(Co_SpinToTarget());
    }

    protected virtual IEnumerator Co_SpinToTarget()
    {
        _spinDelay.Reset();
        _movement.IsSpin(true);
        _animation.SetSpin(true);
        _direction = (_target.transform.position - transform.position).normalized;
        _animation.SetDirection(_direction);

        while (!_spinDelay.IsReady())
        {
            _rigidbody.MovePosition(transform.position + _direction * _speedSpin * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        _movement.IsSpin(false);
        _animation.SetSpin(false);
        StartRandowmAction();
        yield return null;
    }

    private void StartRandowmAction()
    {
        int random = Random.Range(0, _rate);
        Debug.Log(random);
        if (random < _ratePatrol)
        {
            StartState(Co_PatrolAttack());
            return;
        }
        if (random < _rateSpinToTarget)
        {
            StartState(Co_PrepareToSpin());
            return;
        }
        if (random < _rateThrow)
        {
            StartState(Co_ThrowStar(_throwCount));
            return;
        }
    }

    public void OnHited()
    {
        StopCoroutine(_current);
        StartRandowmAction();
    }

    public void Throw()
    {
        _starSpawner.Spawn();
    }

    private void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        SetDirectionToTarget(Vector2.zero);
        _current = StartCoroutine(corotine);
    }

    private void SetDirectionToTarget(Vector2 direction)
    {
        _movement.SetDirection(direction);
        _animation.SetDirection(direction);
    }

    private void LookAtTarget()
    {
        bool _targetIsLeft = _target.transform.position.x - transform.position.x < 0 ? true : false;
        var scale = _targetIsLeft ? new Vector3(-_defaultScale.x, _defaultScale.y, _defaultScale.z) : _defaultScale;
        transform.localScale = scale;
    }

    public void OnDie()
    {
        _movement.IsSpin(false);
        _animation.SetSpin(false);
        _animation.SetPrepare(false);

        SetDirectionToTarget(Vector2.zero);

        if (_current != null)
            StopAllCoroutines();
    }
}

[Serializable]
public class BossPhase
{
    [SerializeField] private int _ratePatrol;
    [SerializeField] private int _rateSpinToTarget;
    [SerializeField] private int _rateThrow;
    [SerializeField] private int _throwCount;
    [SerializeField, Range(0, 100)] private int _percentageHpToEnter;

    public int RatePatrol => _ratePatrol;
    public int RateSpinToTarget => _rateSpinToTarget;
    public int RateThrow => _rateThrow;
    public int ThrowCount => _throwCount;
    public int PercentageHpToEnter => _percentageHpToEnter;
}

