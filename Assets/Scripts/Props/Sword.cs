using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private int _swordValue=1;
    public void AddSword(GameObject target)
    {
        if (target.TryGetComponent(out Inventory inventory))
        {
            inventory.AddInInventoryData("Sword", _swordValue);
        }
    }
    public void Armed(GameObject target)
    {
        if(target.TryGetComponent(out HeroAnimations _animator))
        {
            _animator.Armed();
        }
    }
}
