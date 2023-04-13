using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public void AddSword(GameObject target)
    {
        if (target.TryGetComponent(out Inventory inventory))
        {
            inventory.AddSword();
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
