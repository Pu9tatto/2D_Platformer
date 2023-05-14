using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : CreaturesMovement
{
    [SerializeField] protected CheckCircleOverlap _groundCheckOverlap;

    [SerializeField] private int _multiplyJump;
    [SerializeField] private PlaysSoundsComponent _sounds;

    private int _multiplyJumpyIndex = 0;
    private bool _canMultiplyJump;
    private bool _isJumpPress;

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
        IsGrounded();
        Jump();
    }

    public void IsGrounded()
    {
        if (_groundCheckOverlap.IsContact())
        {
            _multiplyJumpyIndex = 0;
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
        var isFalling = _rigidbody.velocity.y < 0.001;
        _canMultiplyJump = _multiplyJumpyIndex < _multiplyJump;
        if (_isJumpPress)
        {
            if (isFalling)
            {
                if (_canMultiplyJump)
                {
                    AddJumpForce();
                    _multiplyJumpyIndex++;
                }
            }
        }
        else if (!isFalling && !_isDamageJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }
    }

    public void HoldJump() => _isJumpPress = true;
    public void CancelJump() => _isJumpPress = false;

    protected override void AddJumpForce()
    {
        base.AddJumpForce();
        _sounds.Play("Jump");
    }

    public override void AddJumpDamageForce()
    {
        _isDamageJump = true;
        //base.AddJumpDamageForce();
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
