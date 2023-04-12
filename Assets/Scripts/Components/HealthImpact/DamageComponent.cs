using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private int _damage;

    public void ChangeHealth(GameObject target)
    {
        if(target.TryGetComponent(out HealthComponent health))
        {
            health.ChangeHealth(-_damage);
        }
    }
}
