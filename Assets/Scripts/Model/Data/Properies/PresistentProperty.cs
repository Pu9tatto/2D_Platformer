using System;
using UnityEngine;

[Serializable]
public abstract class PresistentProperty<TPropertyType>
{
    [SerializeField] protected TPropertyType _value;
    protected TPropertyType _stored;

    private TPropertyType _defoultValue;

    public PresistentProperty(TPropertyType defaultValue)
    {
        _defoultValue = defaultValue;
    }

    public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);

    public event OnPropertyChanged OnChanged;

    public TPropertyType Value
    {
        get => _stored;
        set
        {
            var isEquels = _stored.Equals(value);
            if (isEquels) return;

            var oldValue = _value;
            Write(value);
            _stored = _value = value;

            OnChanged?.Invoke(value, oldValue);
        }
    }

    protected void Init()
    {
        _stored = _value = Read(_defoultValue);
    }

    public void Validate()
    {
        if (!_stored.Equals(_value))
            Value = _value;
    }

    protected abstract void Write(TPropertyType value);
    protected abstract TPropertyType Read(TPropertyType defaultValue);
}