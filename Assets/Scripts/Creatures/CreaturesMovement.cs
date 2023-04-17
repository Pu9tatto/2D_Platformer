using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CreaturesMovement : MonoBehaviour, IControllable
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage = 1;

    [Space]
    [Header("JumpSetting")]
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _jumpDamageForce;

    [SerializeField] protected ColliderCheck _groundCheck;
    [SerializeField] protected CheckCircleOverlap _checkDamageableProps;

    protected Vector2 _direction;
    protected Vector3 _scale;
    protected bool _isDamageJump = false;
    protected bool _isGround;

    protected Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        _scale = transform.localScale;
    }

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
        IsGrounded();
        Move();
        //Jump();
    }

    public virtual void IsGrounded()
    {
        _isGround = _groundCheck.IsTouchingLayer;
    }


    public virtual void Move()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        if (_direction.x > 0)
        {
            transform.localScale = _scale;
        }
        if (_direction.x < 0)
        {
            var flipScale = new Vector3(-_scale.x, _scale.y, _scale.z);
            transform.localScale = flipScale;
        }
    }

    public virtual void Jump()
    {
    }

    protected virtual void AddJumpForce()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public virtual void AddJumpDamageForce()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpDamageForce);
    }

    public virtual void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public virtual void Interact()
    {
    }

    public virtual void Attack()
    {
        var list = _checkDamageableProps.Check();

        foreach (var props in list)
        {
            if (props.TryGetComponent(out HealthComponent attackTarget))
            {
                attackTarget.ChangeHealth(-_damage);
            }
        }
    }
}
