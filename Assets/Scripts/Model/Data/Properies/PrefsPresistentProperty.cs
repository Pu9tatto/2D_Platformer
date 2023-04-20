public abstract class PrefsPresistentProperty<TPropertyType> : PeresistentProperty<TPropertyType>
{
    protected string Key;
    private float defaultValue;

    protected PrefsPresistentProperty(TPropertyType defaultValue, string key) : base(defaultValue)
    {
        Key = key;
    }
}
