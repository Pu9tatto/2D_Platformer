using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onDie;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ChangeHealth(int value)
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
            if(_health >= _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }

}
