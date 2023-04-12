using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkyAI : MonoBehaviour
{
    [SerializeField] private LayerCheck _vision;
    [SerializeField] private LayerCheck _canAttack;
    [SerializeField] private float _attackCooldown;

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
        _target = go;

        StartState(AgroToHero());
    }

    private IEnumerator AgroToHero()
    {
        _alarmParticle.SetActive(true);
        yield return new WaitForSeconds(_alarmDuration);
        _alarmParticle.SetActive(false);
        StartState(GoToHero());
    }

    private IEnumerator GoToHero()
    {
        while(_vision.IsTouchingLayer)
        {
            if(_canAttack.IsTouchingLayer)
            {
                StartState(Attack());
            }
            else
            {
                var direction = (_target.transform.position - transform.position).normalized;
                SetDirectionToTarget(direction);
            }
            yield return null;
        }

        _missParticle.SetActive(true);
        yield return new WaitForSeconds(_missDuration);
        _missParticle.SetActive(false);
        StartState(_patrol.DoPatrol());
        
    }

    private IEnumerator Attack()
    {
        while (_canAttack.IsTouchingLayer)
        {
            _animation.SetAttack();
            yield return new WaitForSeconds(2f);
        }

        StartState(GoToHero());
    }

    private void SetDirectionToTarget(Vector2 direction)
    {
        direction.y = 0;
        _movement.SetDirection(direction);
        _animation.SetDirectionX(direction.x);
    }

    private IEnumerator Patrolling()
    {
        yield return null;
    }

    private void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        SetDirectionToTarget(Vector2.zero);
        _current = StartCoroutine(corotine);
    }

    private IEnumerator SetDialogParticle(GameObject particle, float duration)
    {
        particle.SetActive(true);
        yield return new WaitForSeconds(duration);
        particle.SetActive(false);
    }

}
