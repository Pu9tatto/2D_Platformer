public class HeroHealthComponent : HealthComponent
{
    private HeroData _data;

    private void Start()
    {
        _data = GameSession.Session.Data;
        _health = _data.Hp.Value;
    }

    public override void ChangeHealth(int value)
    {
        base.ChangeHealth(value);
        _data.Hp.Value = _health;
    }
}
