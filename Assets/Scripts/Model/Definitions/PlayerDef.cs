using UnityEngine;

[CreateAssetMenu(menuName = "Defs/PlayerDef", fileName = "PlayerDef")]

public class PlayerDef : ScriptableObject
{
    [SerializeField] private int _inventorySize;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _lives;

    public int InventorySize => _inventorySize;
    public int MaxHealth => _maxHealth;
    public int Lives => _lives;
}
