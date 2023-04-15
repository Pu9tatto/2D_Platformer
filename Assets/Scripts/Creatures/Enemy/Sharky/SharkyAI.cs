using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkyAI : MonoBehaviour
{
    [SerializeField] private LayerCheck _vision;
    [SerializeField] private LayerCheck _canAttack;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _delayBeforeAttack = 0.5f;

    [Header("Particles")]
    [SerializeField] private GameObject _alarmParticle;
    [SerializeField] private float _alarmDuration = 0.5f;
    [SerializeField] private GameObject _missParticle;
    [SerializeField] private float _missDuration = 0.5f;

    private Coroutine _current;
    private GameObject _target;
    private CreaturesMovement _movement;
    private CreatureAnimation _animation;
    private Patrol _patrol;
    private bool _isDie = false;


    private void Awake()
    {
        _movement = GetComponent<CreaturesMovement>();
        _animation = GetComponent<CreatureAnimation>();
        _patrol = GetComponent<Patrol>();
    }

    private void Start()
    {
        StartState(_patrol.DoPatrol());
    }

    public void OnHeroInVision(GameObject go)
    {
        if (_isDie) return;

        _target = go;
        StartState(Co_AgroToHero());
    }

    private IEnumerator Co_AgroToHero()
    {
        StartCoroutine(Co_Diolog(_alarmParticle, _alarmDuration));
        yield return new WaitForSeconds(_alarmDuration);
        StartState(Co_GoToHero());
        yield return null;
    }

    private IEnumerator Co_GoToHero()
    {
        while (_vision.IsTouchingLayer)
        {
            if (_canAttack.IsTouchingLayer)
            {
                StartState(Co_Attack());
            }
            else
            {
                var direction = (_target.transform.position - transform.position).normalized;
                SetDirectionToTarget(direction);
            }
            yield return null;
        }
        yield return null;
        StartState(_patrol.DoPatrol());
        StartCoroutine(Co_Diolog(_missParticle, _missDuration));


    }

    private IEnumerator Co_Attack()
    {
        yield return new WaitForSeconds(_delayBeforeAttack);
        while (_canAttack.IsTouchingLayer)
        {
            _animation.TrySetAttack();
            yield return new WaitForSeconds(_attackCooldown);
        }

        StartState(Co_GoToHero());
    }

    private void SetDirectionToTarget(Vector2 direction)
    {
        direction.y = 0;
        _movement.SetDirection(direction);
        _animation.SetDirectionX(direction.x);
    }

    private void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        SetDirectionToTarget(Vector2.zero);
        _current = StartCoroutine(corotine); ;
    }

    public void OnDie()
    {
        _isDie = true;
        SetDirectionToTarget(Vector2.zero);

        if (_current != null)
            StopAllCoroutines();

    }

    private IEnumerator Co_Diolog(GameObject _particle, float _duration)
    {
        _particle.SetActive(true);
        yield return new WaitForSeconds(_duration);
        _particle.SetActive(false);
    }
}
