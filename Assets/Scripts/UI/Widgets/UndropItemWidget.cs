using UnityEngine;
using UnityEngine.UI;

public class UndropItemWidget : MonoBehaviour
{
    [InventoryId, SerializeField] private string _itemId;
    [SerializeField] private Text _text;

    private InventoryData _inventory;

    private void Start()
    {
        _inventory = GameSession.Session.Data.Inventory;
        _inventory.OnChanged += OnItemChanged;

        OnItemChanged(_itemId, 0);
    }

    private void OnItemChanged(string id, int value)
    {
        if (id == _itemId)
            _text.text = _inventory.GetCount(id).ToString();
    }

    private void OnDestroy()
    {
        _inventory.OnChanged -= OnItemChanged;
    }
}
