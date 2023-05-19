using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StarAI : MonoBehaviour
{
    [SerializeField] private UnityEvent _startCoroutine;

    [SerializeField] private ColliderCheck _vision;
    [SerializeField] private float _speedSpin;
    [SerializeField] private Cooldown _spinDelay;
    [SerializeField] private float _timeToPrepareForSpin = 1f;

    private Coroutine _current;
    private StarMovement _movement;
    protected StarAnimation _animation;
    private Rigidbody2D _rigidbody;
    protected Patrol _patrol;
    protected Vector3 _direction;
    protected bool _isDie = false;
    protected bool _isPrepare = false;
    protected bool _isSpin = false;


    protected virtual void Awake()
    {
        _movement = GetComponent<StarMovement>();
        _animation = GetComponent<StarAnimation>();
        _patrol = GetComponent<Patrol>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        _startCoroutine?.Invoke();
    }

    public void OnStartPatrol()
    {
        StartState(_patrol.DoPatrol());
    }

    public void OnHeroInVision(GameObject go)
    {
        if (_isDie) return;
        if (_isPrepare) return;
        if(_isSpin) return; 

        _direction = (go.transform.position - transform.position).normalized;
        StartState(Co_PrepareToSpin());
    }
    public IEnumerator Co_PrepareToSpin()
    {
        _animation.SetPrepare(true);
        _isPrepare = true;
        yield return new WaitForSeconds(_timeToPrepareForSpin);
        _animation.SetPrepare(false);
        _isPrepare = false;

        StartState(Co_SpinToTarget());
    }

    private IEnumerator Co_SpinToTarget()
    {
        _spinDelay.Reset();
        _movement.IsSpin(true);
        _animation.SetSpin(true);
        _isSpin = true;
        while (!_spinDelay.IsReady())
        {
            _rigidbody.MovePosition(transform.position + _direction * _speedSpin * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
        _movement.IsSpin(false);
        _animation.SetSpin(false);
        _isSpin = false;
        StartState(_patrol.DoPatrol());
    }


    private void SetDirectionToTarget(Vector2 direction)
    {
        _movement.SetDirection(direction);
        _animation.SetDirection(direction);
    }

    protected void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        SetDirectionToTarget(Vector2.zero);
        _current = StartCoroutine(corotine);
    }

    public void OnHited()
    {

    }

    public virtual void OnDie()
    {
        _isDie = true;
        _movement.IsSpin(false);
        _animation.SetSpin(false);
        _animation.SetPrepare(false);

        SetDirectionToTarget(Vector2.zero);

        if (_current != null)
            StopAllCoroutines();

    }

}
