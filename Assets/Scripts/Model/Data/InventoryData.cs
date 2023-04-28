using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class InventoryData
{
    [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

    public delegate void OnInventoryChanged(string id, int value);
    public OnInventoryChanged OnChanged;

    private bool _isFool => _inventory.Count >= DefsFacade.I.Player.InventorySize;

    public bool IsFool => _isFool;

    public InventoryItemData GetItem(string id)
    {
        foreach (var item in _inventory)
        {
            if (item.Id == id)
                return item;
        }
        return null;
    }

    public InventoryItemData[] GetAll(params ItemTag[] tags)
    {
        var retValue = new List<InventoryItemData>();
        foreach(var item  in _inventory)
        {
            var itemDef = DefsFacade.I.Items.Get(item.Id);
            var isAllRequirementsMet = tags.All(x=> itemDef.HasTag(x));
            if(isAllRequirementsMet)
                retValue.Add(item);
        }

        return retValue.ToArray();
    }

    public void Add(string id, int value)
    {
        if (value < 0) return;

        var ItemDef = DefsFacade.I.Items.Get(id);
        if (ItemDef.isVoid) return;

        if (ItemDef.HasTag(ItemTag.Stackable))
        {
            var item = GetItem(id);

            if (item == null)
            {
                if (_isFool) return;

                item = new InventoryItemData(id);
                _inventory.Add(item);
            }

            item.Value += value;
        }
        else
        {
            for(int i = 0; i < value; i++)
            {
                if(_isFool) return;

                var item = new InventoryItemData(id); { item.Value = 1; };
                _inventory.Add(item);
            }
        }
        OnChanged?.Invoke(id, GetCount(id));
    }

    public void Remove(string id, int value)
    {
        var ItemDef = DefsFacade.I.Items.Get(id);
        if (ItemDef.isVoid) return;

        var item = GetItem(id);
        if (item == null) return;

        item.Value -= value;

        if (!ItemDef.HasTag(ItemTag.Undrop))
        {
            if (item.Value <= 0)
            {
                _inventory.Remove(item);
            }
        }
        OnChanged?.Invoke(id, GetCount(id));
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
    [InventoryId] public string Id;
    public int Value;

    public InventoryItemData(string id)
    {
        Id = id;
    }
}
