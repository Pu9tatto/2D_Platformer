using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] protected LayerCheck _groundCheck;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    private static readonly int IsRunningKey = Animator.StringToHash("is-running");
    private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velosity");


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        LookAtUpdate();

    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        SetAnimatirs();
    }

    private void SetAnimatirs()
    {
        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsRunningKey, _direction.x != 0);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        var isJumping = _direction.y > 0;
        if (isJumping)
        {
            if (IsGrounded())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
        else if (_rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }
    }

    private void LookAtUpdate()
    {
        if (_direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (_direction.x < 0)
            _spriteRenderer.flipX = true;
    }

    private bool IsGrounded() => _groundCheck.CheckTouchingLayer();
}
