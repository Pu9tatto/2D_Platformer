using System.Collections.Generic;
using UnityEngine;

public class QuickInventoryController : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private InventoryItemWidget _prefab;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();

    private GameSession _session;
    private List<InventoryItemWidget> _createdItem = new List<InventoryItemWidget>();

    private void Start()
    {
        
        _session = FindObjectOfType<GameSession>();
        _trash.Retain(_session.QuickInvetory.Subscribe(Rebuild));
        Rebuild();
    }

    private void Rebuild()
    {
        var inventory = _session.QuickInvetory.Inventory;

        for (var i = _createdItem.Count; i < inventory.Length; i++)
        {
            var item = Instantiate(_prefab, _container);
            _createdItem.Add(item);
        }

        for (var i = 0; i < inventory.Length; i++)
        {
            _createdItem[i].SetData(inventory[i], i);
            _createdItem[i].gameObject.SetActive(true);
        }

        for(int i = inventory.Length; i<_createdItem.Count; i++)
        {
            _createdItem[i].gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        _trash.Dispose();
    }
}
