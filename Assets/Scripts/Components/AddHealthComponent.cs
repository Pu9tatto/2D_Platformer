using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;

    public void AddHealth(GameObject target)
    {
        if (target.TryGetComponent(out HealthComponent health))
        {
            health.ChangeHealth(_health);
        }
    }
}
