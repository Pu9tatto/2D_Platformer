using System.Collections.Generic;
using UnityEngine;

public class QuickInventoryController : MonoBehaviour, IItemRenderer<InventoryItemData>
{
    [SerializeField] private Transform _container;
    [SerializeField] private InventoryItemWidget _prefab;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();

    private GameSession _session;
    private List<InventoryItemWidget> _createdItem = new List<InventoryItemWidget>();

    private DataGroup<InventoryItemData, InventoryItemWidget> _dataGroup;

    private void Start()
    {
        _dataGroup = new DataGroup<InventoryItemData, InventoryItemWidget> (_prefab, _container);
        _session = FindObjectOfType<GameSession>();
        _trash.Retain(_session.QuickInvetory.Subscribe(Rebuild));
        Rebuild();
    }

    private void Rebuild()
    {
        var inventory = _session.QuickInvetory.Inventory;
        _dataGroup.SetData(inventory);
    }
    private void OnDestroy()
    {
        _trash.Dispose();
    }

    public void SetData(InventoryItemData data, int index)
    {
    }
}
