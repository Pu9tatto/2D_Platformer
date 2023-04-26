using UnityEngine;
using UnityEngine.Events;

public class RequireCheckItem : MonoBehaviour
{
    [InventoryId, SerializeField] private string _item;
    [SerializeField] private int _value;
    [SerializeField] private UnityEvent _successAction;
    [SerializeField] private UnityEvent _wrongAction;

    private InventoryData _inventory;

    private void Start()
    {
        _inventory = GameSession.Session.Data.Inventory;
    }

    public void Check()
    {
        if (_inventory.GetCount(_item) >= _value)
        {
            _successAction?.Invoke();
            _inventory.Remove(_item, _value);
        }
        else
            _wrongAction?.Invoke();

    }

}
