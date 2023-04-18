public abstract class PrefsPresistentProperty<TPropertyType> : PresistentProperty<TPropertyType>
{
    protected string Key;
    private float defaultValue;

    protected PrefsPresistentProperty(TPropertyType defaultValue, string key) : base(defaultValue)
    {
        Key = key;
    }
}
