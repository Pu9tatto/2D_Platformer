using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;

    public void AddCoin(GameObject target)
    {
        if (target.TryGetComponent(out Inventory inventory))
        {
            inventory.AddCoin(_coinValue);
        }
    }
}
