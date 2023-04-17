using System.Collections;
using UnityEngine;

public class StarAI : MonoBehaviour
{
    [SerializeField] private string Co_name;

    [SerializeField] private ColliderCheck _vision;
    [SerializeField] private float _speedSpin;
    [SerializeField] private Cooldown _spinDelay;
    [SerializeField] private float _timeToPrepareForSpin = 1f;

    private Coroutine _current;
    private StarMovement _movement;
    private StarAnimation _animation;
    private Rigidbody2D _rigidbody;
    private Patrol _patrol;
    private Vector3 _direction;
    private bool _isDie = false;


    private void Awake()
    {
        _movement = GetComponent<StarMovement>();
        _animation = GetComponent<StarAnimation>();
        _patrol = GetComponent<Patrol>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartState(_patrol.DoPatrol());
        Co_name = "patrol";
    }

    public void OnHeroInVision(GameObject go)
    {
        if (_isDie) return;
        _direction = (go.transform.position - transform.position).normalized;
        StartState(Co_PrepareToSpin());
    }
    private IEnumerator Co_PrepareToSpin()
    {
        Co_name = "PrepareToSpin";

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
        while (!_spinDelay.IsReady())
        {
            _rigidbody.MovePosition(transform.position + _direction * _speedSpin * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
        _movement.IsSpin(false);
        _animation.SetSpin(false);
        StartState(_patrol.DoPatrol());
        Co_name = "patrol";
    }


    private void SetDirectionToTarget(Vector2 direction)
    {
        _movement.SetDirection(direction);
        _animation.SetDirection(direction);
    }

    private void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        SetDirectionToTarget(Vector2.zero);
        _current = StartCoroutine(corotine);
    }

    public void OnDie()
    {
        _isDie = true;
        SetDirectionToTarget(Vector2.zero);

        if (_current != null)
            StopAllCoroutines();

    }
}
