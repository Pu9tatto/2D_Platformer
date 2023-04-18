using System.Collections;
using UnityEngine;


public class ObservableProperty<TPropertryType>
{
    [SerializeField] private TPropertryType _value;

    public delegate void OnPropertyChanged(TPropertryType newValue, TPropertryType oldValue);

    public event OnPropertyChanged OnChanged;

    public TPropertryType Value
    {
        get => _value;
        set
        {
            var isSame = _value.Equals(value);
            if (isSame) return;
            var oldValue = _value;

            _value = value;
            OnChanged?.Invoke(_value, oldValue);
             
        }
    }


}
