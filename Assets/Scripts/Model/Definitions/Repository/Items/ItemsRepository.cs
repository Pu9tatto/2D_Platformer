using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName ="Defs/Items", fileName = "Items")]
public class ItemsRepository : RepositoryDef<ItemDef>
{
#if UNITY_EDITOR
    public ItemDef[] ItemsForEditor => _collection;
#endif
}

[Serializable]
public struct ItemDef : IHaveId
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemTag[] _tags;
    public string Id => _id;
    public Sprite Icon => _icon;
    public bool isVoid => string.IsNullOrEmpty(_id);

    public bool HasTag(ItemTag tag) => _tags?.Contains(tag)??false;
}

public enum ItemTag
{
    Stackable,
    Undrop,
    Usable,
    Throwable,
    Potion
}
