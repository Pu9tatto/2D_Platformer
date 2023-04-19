public class HeroHealthComponent : HealthComponent
{
    private HeroData _data;

    protected override void Start()
    {
        _data = GameSession.Session.Data;
        _health = _data.Hp.Value;
        _maxHealth = DefsFacade.I.Player.MaxHealth;
        if(_health > _maxHealth ) 
            _health = _maxHealth;
    }

    public override void ChangeHealth(int value)
    {
        base.ChangeHealth(value);
        _data.Hp.Value = _health;
    }
}
