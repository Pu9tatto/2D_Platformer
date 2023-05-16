using UnityEngine;


public class Good : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] protected int _count;
    [SerializeField][InventoryId] protected string _id;
    [SerializeField][InventoryId] private string _currency;

    protected HeroData _data;
    protected InventoryData _inventory;

    private void Start()
    {
        _data = GameSession.Session.Data;
        _inventory = _data.Inventory;
    }

    public string Id => _id;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Count => _count;

    public void CheckEnoughtCurrency()
    {
        if(_inventory.IsEnough(_price))
        {
            TryBuy();
        }
    }
    
    protected virtual void TryBuy()
    {
        _inventory.Remove(_currency, _price);
    }
}

