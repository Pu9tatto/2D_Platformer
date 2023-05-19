using UnityEngine;

public class HeroAnimations : CreatureAnimation
{
    [SerializeField] private float _speedForHithgFall;

    [SerializeField] private Cooldown _attackCooldown;

    [SerializeField] private RuntimeAnimatorController _armed;
    [SerializeField] private RuntimeAnimatorController _disArmed;
    [SerializeField] private Cooldown _throwCooldown;
    
    private bool _isHightFall;
    private bool _isArmed;
    private InventoryData _inventory;

    private static readonly int IsHightFallKey = Animator.StringToHash("is-hightFall");
    private static readonly int ThrowKey = Animator.StringToHash("throw");

    private int _swordsValue => _inventory.GetCount("Sword");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _inventory = GameSession.Session.Data.Inventory;
        _isArmed = _swordsValue > 0;
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
        if (_isArmed) return;

        UpdateArmed();
    }

    public void DisArmed()
    {
        UpdateArmed();
    }

    protected override void SetAnimations()
    {
        _animator.SetBool(IsHightFallKey, _isHightFall);
        base.SetAnimations();
    }

    public override void TrySetAttack()
    {
        if (!_isArmed) return;

        if (_attackCooldown.IsReady())
        {
            base.TrySetAttack();
            _attackCooldown.Reset();
        }
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

    public override void SetDirection(Vector2 direction)
    {
        base.SetDirection(direction);
    }

    public override bool IsGrounded() =>
        base.IsGrounded();

    public void TryThrow()
    {
        if (_throwCooldown.IsReady())
        {
            _animator.SetTrigger(ThrowKey);
            _throwCooldown.Reset();
        }
    }

    private void UpdateArmed()
    {
        if(_swordsValue > 0)
        {
            _animator.runtimeAnimatorController = _armed;
            _isArmed = true;
        }
        else
        {
            _animator.runtimeAnimatorController = _disArmed;
            _isArmed = false;
        }
    }
}
