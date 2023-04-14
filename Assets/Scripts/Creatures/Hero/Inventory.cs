using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryData _inventory;

    private void Start()
    {
        _inventory = GameSession.Session.Data.Inventory;
    }

    public void AddInInventoryData(string id, int value)
    {
        _inventory.Add(id, value);
    }

    public void RemoveInInventoryData(string id, int value)
    {
        _inventory.Remove(id, value);
    }

    public int Count(string id) => _inventory.GetCount(id);
}
