using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryData
{
    [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

    private int _itemsCount = 0;

    private bool _inventoryIsFool => _itemsCount >= DefsFacade.I.Capacity;

    private InventoryItemData GetItem(string id)
    {
        foreach (var item in _inventory)
        {
            if (item.Id == id)
                return item;
        }
        return null;
    }

    public void Add(string id, int value)
    {
        if (value < 0) return;

        var ItemDef = DefsFacade.I.Items.Get(id);
        if (ItemDef.isVoid) return;

        var item = GetItem(id);

        if (item == null)
        {
            item = new InventoryItemData(id);
            _inventory.Add(item);
        }

        item.Value += value;
        
    }

    private void TryAddNewItem(InventoryItemData item, string id)
    {
        if (_inventoryIsFool) return;
        item = new InventoryItemData(id);
        _inventory.Add(item);
        _itemsCount++;
    }

    public void Remove(string id, int value)
    {
        var ItemDef = DefsFacade.I.Items.Get(id);
        if (ItemDef.isVoid) return;

        var item = GetItem(id);
        if (item == null) return;

        item.Value -= value;

        if (item.Value <= 0)
        {
            _inventory.Remove(item);
            _itemsCount--;
        }
    }

    public int GetCount(string id)
    {
        var count = 0;
        foreach (var item in _inventory)
        {
            if (item.Id == id)
                count += item.Value;
        }
        return count;
    }
}

[Serializable]
public class InventoryItemData
{
    public string Id;
    public int Value;

    public InventoryItemData(string id)
    {
        Id = id;
    }
}
