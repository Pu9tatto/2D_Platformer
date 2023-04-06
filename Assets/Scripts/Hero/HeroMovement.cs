using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;

    [Space]
    [Header("JumpSetting")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDamageForce;
    [SerializeField] private int _multiplyJump;
    [SerializeField] private LayerCheck _groundCheck;

    [Space]
    [Header("InteractSetting")]
    [SerializeField] private float _interactRadius;
    [SerializeField] private LayerMask _interactLayer;

    private Vector2 _direction;
    private int _multiplJumpyIndex = 0;
    private bool _canMultiplyJump;
    private bool _isDamageJump = false;
    private bool _isGround;
    private Collider2D[] _interactResults = new Collider2D[1];

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsGrounded();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    public void Move()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        if(_direction.x>0)
            transform.localScale = Vector3.one;
        if(_direction.x<0)
            transform.localScale = new Vector3(-1,1,1);
    }

    public void Jump()
    {
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
    private void AddJumpForce()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void AddJumpDamageForce()
    {
        _isDamageJump = true;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpDamageForce);
    }

    public void SetDirection(Vector2 direction) =>
        _direction = direction;

    public void IsGrounded()
    {
        _isGround = _groundCheck.IsTouchingLayer;
        if (_isGround)
        {
            _multiplJumpyIndex = 0;
            _isDamageJump = false;
        }
    }

    public void Interact()
    {

        var size = Physics2D.OverlapCircleNonAlloc(
            transform.position,
            _interactRadius,
            _interactResults,
            _interactLayer);

        for(int i = 0; i < size; i++)
        {
            if(_interactResults[i].TryGetComponent(out InteractableComponent component))
            {
                component.Interact();
            }
        }
    }
}
