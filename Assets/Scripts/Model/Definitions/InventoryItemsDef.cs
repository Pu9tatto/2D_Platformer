using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Defs/InventoryItems", fileName ="InventoruItems")]
public class InventoryItemsDef : ScriptableObject
{
    [SerializeField] private ItemDef[] _items;

    public ItemDef Get(string id)
    {
        foreach (ItemDef item in _items)
        {
            if(item.Id == id)
                return item;
        }
        return default;
    }
}

[Serializable]
public struct ItemDef 
{
    [SerializeField] private string _id;

    public string Id => _id;
    public bool isVoid => string.IsNullOrEmpty(_id);
}
