using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class HeroAnimations : MonoBehaviour
{
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private float _speedForHithgFall;

    [SerializeField] private AnimatorController _armed;
    [SerializeField] private AnimatorController _disArmed;

    private HeroParticleManager _particleCreator;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isHightFall;
    private bool _isHorizontalMovement;
    private bool _isFlip;
    private HeroData _data;

    private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
    private static readonly int IsRunningKey = Animator.StringToHash("is-running");
    private static readonly int IsHightFallKey = Animator.StringToHash("is-hightFall");
    private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velosity");
    private static readonly int HitKey = Animator.StringToHash("hit");
    private static readonly int DieKey = Animator.StringToHash("die");
    private static readonly int AtatckKey = Animator.StringToHash("attack");


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleCreator = GetComponent<HeroParticleManager>();
    }

    private void Start()
    {
        _data = GameSession.Session.Data;
        UpdateArmed();
    }

    private void LateUpdate()
    {
        if (!_isHightFall)
            CheckHithgFall();

        SetAnimations();

        if (IsGrounded())
        {
            _isHightFall = false;
        }
    }

    public void Armed()
    {
        _data.IsArmed = true;
        UpdateArmed();
    }

    public void DisArmed()
    {
        _data.IsArmed = false;
        UpdateArmed();
    }

    private void SetAnimations()
    {
        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsHightFallKey, _isHightFall);
        _animator.SetBool(IsRunningKey, _isHorizontalMovement);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);

        _spriteRenderer.flipX = _isFlip;
    }

    public void SetAttack()
    {
        if (!_data.IsArmed) return;
        _animator.SetTrigger(AtatckKey);
    }

    private void CheckHithgFall() => _isHightFall = _rigidbody.velocity.y < _speedForHithgFall;

    public void TakeDamageAnimation()
    {
        _animator.SetTrigger(HitKey);
    }

    public void DieAnimation()
    {
        _animator.SetTrigger(DieKey);
    }

    public void SetDirectionX(float directionX) =>
       _isHorizontalMovement = directionX == 0 ? false : true;


    private bool IsGrounded() =>
        _groundCheck.IsTouchingLayer;

    private void UpdateArmed()
    {
        _animator.runtimeAnimatorController = _data.IsArmed ? _armed : _disArmed;
    }
}
