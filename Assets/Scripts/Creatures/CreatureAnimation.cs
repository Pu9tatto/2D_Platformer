using UnityEngine;

public class CreatureAnimation : MonoBehaviour
{
    [SerializeField] protected LayerCheck _groundCheck;

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
    }

    protected virtual void SetAnimations()
    {
        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsRunningKey, _isHorizontalMovement);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
    }
    public virtual void SetAttack()
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

    public virtual void SetDirectionX(float directionX) =>
   _isHorizontalMovement = directionX == 0 ? false : true;


    protected virtual bool IsGrounded() =>
        _groundCheck.IsTouchingLayer;

}
