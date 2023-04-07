using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _coins;
    private int _swords;

    public int GetSwordValue() => _swords;

    public int GetCoinsValue() => _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }

    public void AddSword()
    {
        _swords++;
    }

    public int DropCoins(int valueDropCoins)
    {
        var coinsForDrop = Mathf.Min(_coins, valueDropCoins);
        _coins -= coinsForDrop;
        Debug.Log(_coins);
        return coinsForDrop;
    }
}
