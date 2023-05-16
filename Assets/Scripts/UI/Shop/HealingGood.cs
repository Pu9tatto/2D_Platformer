public class HealingGood : Good
{
    protected override void TryBuy()
    {
        var maxHelth = DefsFacade.I.Player.MaxHealth;
        var health = GameSession.Session.Data.Hp.Value;
        if(health<maxHelth)
        {
            base.TryBuy();
            _data.Hp.Value += _count;
        }
    }
}
