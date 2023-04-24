using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Potions", fileName = "Potions")]
public class PotionRepository : RepositoryDef<PoisonDef>
{

}

[Serializable]
public struct PoisonDef : IHaveId
{
    [InventoryId][SerializeField] private string _id;
    [SerializeField] private float _value;
    [SerializeField] private float _time;

    public string Id => _id;
    public float Value => _value;
    public float Time => _time;
}

