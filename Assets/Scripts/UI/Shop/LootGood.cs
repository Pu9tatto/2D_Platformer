public class LootGood : Good
{
    protected override void TryBuy()
    {
        if (!_inventory.IsFool)
        {
            base.TryBuy();
            _inventory.Add(_id, _count);
            return;
        }
        var itemDef = DefsFacade.I.Items.Get(_id);
        if (!itemDef.HasTag(ItemTag.Stackable))
            return;

        var item = _inventory.GetItem(_id);
        if (item != null)
        {
            base.TryBuy();
            _inventory.Add(_id, _count);
        } 
    }
}
