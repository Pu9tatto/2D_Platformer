public class HeroHealthComponent : HealthComponent
{
    private HeroData _data;

    private void Start()
    {
        _data = GameSession.Session.Data;
        _health = _data.Health;
    }

    public override void ChangeHealth(int value)
    {
        base.ChangeHealth(value);
        _data.Health = _health;
    }
}
