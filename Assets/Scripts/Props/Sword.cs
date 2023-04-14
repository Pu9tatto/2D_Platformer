using UnityEngine;

public class Sword : MonoBehaviour
{
    public void Armed(GameObject target)
    {
        if(target.TryGetComponent(out HeroAnimations _animator))
        {
            _animator.Armed();
        }
    }
}
