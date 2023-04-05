using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour
{
    [SerializeField] private LayerCheck _groundCheck;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isHorizontalMovement;
    private bool _isFlip;
    private float _directionX;

    private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    private static readonly int IsRunningKey = Animator.StringToHash("is-running");
    private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velosity");
    private static readonly int HitKey = Animator.StringToHash("hit");
    private static readonly int DieKey = Animator.StringToHash("die");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        SetAnimations();
    }

    private void SetAnimations()
    {
        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsRunningKey, _isHorizontalMovement);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);

        _spriteRenderer.flipX = _isFlip;
    }

    public void TakeDamageAnimation()
    {
        _animator.SetTrigger(HitKey);
    }

    public void DieAnimation()
    {
        _animator.SetTrigger(DieKey);
    }


    public void SetDirectionX(float directionX)
    {
        _directionX = directionX;
        if (_directionX > 0)
        {
            _isFlip = false;
            _isHorizontalMovement = true;
        }
        else if(_directionX < 0)
        {
            _isFlip = true;
            _isHorizontalMovement = true;
        }
        else
            _isHorizontalMovement = false;

    }

    private bool IsGrounded() => _groundCheck.IsTouchingLayer;
}
