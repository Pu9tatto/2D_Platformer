public class HealingGood : Good
{
    protected override void Buy()
    {
        _data.Hp.Value += _count;
    }
}
