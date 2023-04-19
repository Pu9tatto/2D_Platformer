using System;
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

#if UNITY_EDITOR
    public ItemDef[] ItemsForEditor => _items;
#endif
}

[Serializable]
public struct ItemDef 
{
    [SerializeField] private string _id;
    [SerializeField] private bool _isStackable;
    public string Id => _id;
    public bool IsStackable => _isStackable;
    public bool isVoid => string.IsNullOrEmpty(_id);
}
