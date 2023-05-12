using System;
using System.Collections.Generic;
using UnityEngine;


public class ShopWidget : MonoBehaviour
{
    [SerializeField] private Transform _containter;
    public event Action CloseAction;
    public void InitGoods(List<Good> goods)
    {
        foreach (var good in goods)
        {
            Instantiate(good, _containter);
        }
    }
    public void CloseShop()
    {
        CloseAction?.Invoke();
    }
}
