public class LootGood : Good
{
    protected override void Buy()
    {
        _inventory.Add(_id, _count);
    }
}
