using UnityEditor.Animations;
using UnityEngine;

public class HeroAnimations : CreatureAnimation
{
    [SerializeField] private float _speedForHithgFall;

    [SerializeField] private AnimatorController _armed;
    [SerializeField] private AnimatorController _disArmed;

    private bool _isHightFall;
    private HeroData _data;

    private static readonly int IsHightFallKey = Animator.StringToHash("is-hightFall");


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _data = GameSession.Session.Data;
        UpdateArmed();
    }

    protected override void LateUpdate()
    {
        if (!_isHightFall)
            CheckHithgFall();

        base.LateUpdate();

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

    protected override void SetAnimations()
    {
        _animator.SetBool(IsHightFallKey, _isHightFall);
        base.SetAnimations();
    }

    public override void SetAttack()
    {
        if (!_data.IsArmed) return;
        base.SetAttack();
    }

    private void CheckHithgFall() => _isHightFall = _rigidbody.velocity.y < _speedForHithgFall;

    public override void TakeDamageAnimation()
    {
        base.TakeDamageAnimation();
    }

    public override void DieAnimation()
    {
        _animator.SetTrigger(DieKey);
    }

    public override void SetDirectionX(float directionX) =>
       base.SetDirectionX(directionX);


    protected override bool IsGrounded() =>
        base.IsGrounded();

    private void UpdateArmed()
    {
        _animator.runtimeAnimatorController = _data.IsArmed ? _armed : _disArmed;
    }
}
