using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;

    public void AddCoin(GameObject target)
    {
        if (target.TryGetComponent(out Inventary inventory))
        {
            inventory.AddCoin(_coinValue);
        }
    }
}
