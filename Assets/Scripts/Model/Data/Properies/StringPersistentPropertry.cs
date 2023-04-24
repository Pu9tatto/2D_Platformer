using UnityEngine;


public class StringPersistentPropertry : PrefsPresistentProperty<string>
{
    public StringPersistentPropertry(string defaultValue, string key) : base(defaultValue, key)
    {
        Init();
    }
    protected override void Write(string value)
    {
        PlayerPrefs.SetString(Key, value);
    }

    protected override string Read(string defaultValue)
    {
        return PlayerPrefs.GetString(Key, defaultValue);
    }
}
