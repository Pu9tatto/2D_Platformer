using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Goods", fileName = "Goods")]

public class GoodsRepository : RepositoryDef<GoodDef>
{

}
[Serializable]
public struct GoodDef : IHaveId
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private int _count;
    [SerializeField][InventoryId] private string _id;

    public string Id => _id;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Count => _count;
}

