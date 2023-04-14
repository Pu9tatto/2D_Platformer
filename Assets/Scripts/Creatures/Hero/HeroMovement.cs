using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : CreaturesMovement
{
    [SerializeField] private int _multiplyJump;
    [SerializeField] private PlaysSoundsComponent _sounds;

    private int _multiplJumpyIndex = 0;
    private bool _canMultiplyJump;

    protected override void Awake()
    {
        base.Awake(); 
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Jump();
    }

    public override void IsGrounded()
    {
        base.IsGrounded();
        if (_isGround)
        {
            _multiplJumpyIndex = 0;
            _isDamageJump = false;
        }
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Jump()
    {
        base.Jump();
        var isJumpPress = _direction.y > 0;
        var isFalling = _rigidbody.velocity.y < -0.001;
        _canMultiplyJump = _multiplJumpyIndex < _multiplyJump;
        if (isJumpPress)
        {
            if (_isGround)
            {
                AddJumpForce();
            }
            if (isFalling)
            {
                if (_canMultiplyJump)
                {
                    AddJumpForce();
                    _multiplJumpyIndex++;
                }
            }
        }
        else if (!isFalling && !_isDamageJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }
    }
    protected override void AddJumpForce()
    {
        base.AddJumpForce();
        _sounds.Play("Jump");
    }

    public override void AddJumpDamageForce()
    {
        _isDamageJump = true;
        base.AddJumpDamageForce();
    }

    public override void SetDirection(Vector2 direction)
    {
        base.SetDirection(direction);
    }

    public override void Attack()
    {
        base.Attack();
        _sounds.Play("Meele");
    }
}
