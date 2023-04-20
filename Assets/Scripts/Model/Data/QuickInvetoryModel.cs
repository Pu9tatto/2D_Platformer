using System;
using UnityEngine;
public class QuickInvetoryModel : IDisposable
{
    private readonly HeroData _data;

    public InventoryItemData[] Inventory { get; private set; }

    public readonly IntProperty SelectedIndex = new IntProperty();

    public event Action OnChanged;

    public InventoryItemData SelectedItem => Inventory[SelectedIndex.Value];

    public QuickInvetoryModel(HeroData data)
    {
        _data = data;

        Inventory = _data.Inventory.GetAll(ItemTag.Usable);
        _data.Inventory.OnChanged += OnChangedInventory;
    }

    public IDisposable Subscribe(Action call)
    {
        OnChanged += call;
        return new ActionDisposable(() => OnChanged -= call);
    }

    private void OnChangedInventory(string id, int value)
    {
        Inventory = _data.Inventory.GetAll(ItemTag.Usable);
        SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, Inventory.Length - 1);
        OnChanged?.Invoke();
    }
    internal void SetNextItem()
    {
        SelectedIndex.Value = (int)Mathf.Repeat(SelectedIndex.Value + 1, Inventory.Length);
    }

    public void Dispose()
    {
        _data.Inventory.OnChanged -= OnChangedInventory;
    }
}
