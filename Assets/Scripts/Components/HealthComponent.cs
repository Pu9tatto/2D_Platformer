using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _health = 1;
    [SerializeField] protected UnityEvent _onHealth;
    [SerializeField] protected UnityEvent _onDamage;
    [SerializeField] protected UnityEvent _onDie;

    public virtual void ChangeHealth(int value)
    {
        _health += value;

        if(value < 0)
        {
            _onDamage?.Invoke();
            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
        if(value > 0)
        {
            _onHealth?.Invoke();
            if(_health >= _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }

}
