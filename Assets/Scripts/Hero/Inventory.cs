using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _coins;

    public int GetCoinsValue() => _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }

    public int DropCoins(int valueDropCoins)
    {
        var coinsForDrop = Mathf.Min(_coins, valueDropCoins);
        _coins -= coinsForDrop;
        Debug.Log(_coins);
        return coinsForDrop;
    }
}
