using System;
using UnityEngine;

[Serializable]
public class HeroData 
{
    [SerializeField] private InventoryData _inventory;

    public int Health;

    public InventoryData Inventory=> _inventory;

    public HeroData Clone()
    {
        var json = JsonUtility.ToJson(this);
        return JsonUtility.FromJson<HeroData>(json);
    }
}
