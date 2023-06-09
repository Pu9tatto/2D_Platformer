using UnityEngine;

public class CreatureAnimation : MonoBehaviour
{
    [SerializeField] protected CheckCircleOverlap _groundCheck;
    [SerializeField] private bool _testGroundedCheck;

    protected bool _isHorizontalMovement;

    protected Animator _animator;
    protected Rigidbody2D _rigidbody;

    protected static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    protected static readonly int IsRunningKey = Animator.StringToHash("is-running");
    protected static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velosity");
    protected static readonly int HitKey = Animator.StringToHash("hit");
    protected static readonly int DieKey = Animator.StringToHash("is-die");
    protected static readonly int AtatckKey = Animator.StringToHash("attack");



    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void LateUpdate()
    {
        SetAnimations();
        
        _testGroundedCheck = IsGrounded();
    }

    protected virtual void SetAnimations()
    {
        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsRunningKey, _isHorizontalMovement);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
    }
    public virtual void TrySetAttack()
    {
        _animator.SetTrigger(AtatckKey);
    }

    public virtual void TakeDamageAnimation()
    {
        _animator.SetTrigger(HitKey);
    }

    public virtual void DieAnimation()
    {
        _animator.SetBool(DieKey, true);
    }

    public virtual void SetDirection(Vector2 direction) =>
        _isHorizontalMovement = direction.x == 0 ? false : true;

    public void DoMove() => _isHorizontalMovement = true;

    public virtual bool IsGrounded() =>
        _groundCheck.IsContact();

}
