using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropCoins : MonoBehaviour
{
    [SerializeField] private int _maxCount = 5;
    [SerializeField] private GameObject _template;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UnityEvent<List<GameObject>> _onDrop;
    private List<GameObject> _coins = new List<GameObject>();
    
    public void Drop()
    {
        if (_inventory.GetCoinsValue() > 0)
        {
            var coinsCount = _inventory.DropCoins(_maxCount);
            for(int i = 0; i < coinsCount; i++)
            {
                _coins.Add(_template);
            }
            _onDrop?.Invoke(_coins);
            _coins.Clear();
        }
    }
}
