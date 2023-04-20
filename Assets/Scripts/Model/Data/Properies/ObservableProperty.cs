using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class ObservableProperty<TPropertryType>
{
    [SerializeField] protected TPropertryType _value;

    public delegate void OnPropertyChanged(TPropertryType newValue, TPropertryType oldValue);

    public event OnPropertyChanged OnChanged;

    public IDisposable Subscribe(OnPropertyChanged call)
    {
        OnChanged += call;
        return new ActionDisposable(() => OnChanged -= call);
    }

    public IDisposable SubscribeAndInvoke(OnPropertyChanged call)
    {
        OnChanged += call;
        var dispose = new ActionDisposable(() => OnChanged -= call);
        call(_value, _value);
        return dispose;
    }

    public virtual TPropertryType Value
    {
        get => _value;
        set
        {
            var isSame = _value.Equals(value);
            if (isSame) return;
            var oldValue = _value;
            _value = value;
            InvokeChangedEvent(_value, oldValue);
            
        }
    }

    protected void InvokeChangedEvent(TPropertryType newValue, TPropertryType oldValue)
    {
        OnChanged?.Invoke(newValue, oldValue);
    }


}
