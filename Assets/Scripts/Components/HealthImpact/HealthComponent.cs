using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected int _health = 1;
    [SerializeField] protected UnityEvent _onHealth;
    [SerializeField] protected UnityEvent _onDamage;
    [SerializeField] protected UnityEvent _onDie;

    [SerializeField] private ProgressBarWidget _healthBar;

    protected int _maxHealth;

    protected virtual void Start()
    {
        _maxHealth = _health;
    }

    public virtual void ChangeHealth(int value)
    {
        if(value < 0)
        {
            TakeDamage(value);
        }
        if(value > 0)
        {
            Heal(value);
        }
    }

    protected virtual void Heal(int value)
    {
        _health += value;
        _onHealth?.Invoke();
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
    }
    protected virtual void TakeDamage(int value)
    {
        _health += value;
        _onDamage?.Invoke();
        if (_health <= 0)
        {
            _onDie?.Invoke();
        }
    }

    public void SetProgressBar()
    {
        var progress = (float) _health / _maxHealth;
        _healthBar?.SetProgress(progress);
    }

    public void SetHealth(int value)
    {
        _health = value;
    }

}
