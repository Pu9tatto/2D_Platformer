using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropCoins : MonoBehaviour
{
    [SerializeField] private int _maxCount = 5;
    [SerializeField] private GameObject _template;
    [SerializeField] private UnityEvent<List<GameObject>> _onDrop;
    private List<GameObject> _coins = new List<GameObject>();

    private InventoryData _inventory;

    private int _coinsValue => _inventory.GetCount("Coin");


    private void Start()
    {
        _inventory = GameSession.Session.Data.Inventory;
    }

    public void Drop()
    {
        if (_coinsValue > 0)
        {
            var coinsForDrop = Mathf.Min(_maxCount, _coinsValue);
            _inventory.Remove("Coin", coinsForDrop);
            for(int i = 0; i < coinsForDrop; i++)
            {
                _coins.Add(_template);
            }
            _onDrop?.Invoke(_coins);
            _coins.Clear();
        }
    }
}
