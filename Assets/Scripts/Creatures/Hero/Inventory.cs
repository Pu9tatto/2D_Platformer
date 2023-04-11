using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _coins;
    private int _swords;
    private HeroData _data;

    private void Start()
    {
        _data = GameSession.Session.Data;
        _coins = _data.Coins;
    }

    public int GetSwordValue() => _swords;

    public int GetCoinsValue() => _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        UpdateSession();
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
        UpdateSession();
        Debug.Log(_coins);
        return coinsForDrop;
    }

    private void UpdateSession()
    {
        _data.Coins = _coins;
    }
}
