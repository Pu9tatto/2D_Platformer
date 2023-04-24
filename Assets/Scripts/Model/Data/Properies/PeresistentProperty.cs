public abstract class PeresistentProperty<TPropertyType>: ObservableProperty<TPropertyType>
{
    protected TPropertyType _stored;

    private TPropertyType _defoultValue;

    public PeresistentProperty(TPropertyType defaultValue)
    {
        _defoultValue = defaultValue;
    }

    //public event OnPropertyChanged OnChanged;

    public override TPropertyType Value
    {
        get => _stored;
        set
        {
            var isEquels = _stored.Equals(value);
            if (isEquels) return;

            var oldValue = _value;
            Write(value);
            _stored = _value = value;

            InvokeChangedEvent(value, oldValue);
        }
    }

    protected void Init()
    {
        _stored = _value = Read(_defoultValue);
    }

    public void Validate()
    {
        if (!_stored.Equals(_value))
        {
            Value = _value;
        }
    }

    protected abstract void Write(TPropertyType value);
    protected abstract TPropertyType Read(TPropertyType defaultValue);
}