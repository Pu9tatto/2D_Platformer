using UnityEngine;

public class AddItemInCollision : MonoBehaviour
{
    [SerializeField] private int _count;
    [InventoryId][SerializeField] private string _id;

    public void AddItem(GameObject target)
    {
        if (target.TryGetComponent(out Inventory inventory))
        {
            inventory.AddInInventoryData(_id, _count);
        }
    }
}
