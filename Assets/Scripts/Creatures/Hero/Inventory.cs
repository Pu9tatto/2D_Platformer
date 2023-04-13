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
        _swords = _data.Swords;
    }

    public int GetSwordValue() => _swords;

    public int GetCoinsValue() => _coins;

    public void AddCoin(int value)
    {
        _coins += value;
        UpdateCoins();
        Debug.Log(_coins);
    }

    public void AddSword()
    {
        _swords++;
        UpdateSwords();
    }

    public int DropCoins(int valueDropCoins)
    {
        var coinsForDrop = Mathf.Min(_coins, valueDropCoins);
        _coins -= coinsForDrop;
        UpdateCoins();
        Debug.Log(_coins);
        return coinsForDrop;
    }

    public void ThrowSwords()
    {
        _swords--;
        UpdateSwords();
    }

    private void UpdateCoins() =>
        _data.Coins = _coins;

    private void UpdateSwords() =>
    _data.Swords = _swords;
}
