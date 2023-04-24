using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    public readonly static LocalizationManager I;

    private StringPersistentPropertry _localeKey = new StringPersistentPropertry("en", "localization/current");

    private Dictionary<string, string> _localization;

    public string LocalKey => _localeKey.Value;

    public event Action OnLoacalChanged;

    static LocalizationManager()
    {
        I = new LocalizationManager();
    }

    public LocalizationManager()
    {
        LoadLocal(_localeKey.Value);
    }

    private void LoadLocal(string localeToLoad)
    {
        var def = Resources.Load<LocalDef>($"Locales/{localeToLoad}");
        _localization = def.GetData();
        _localeKey.Value = localeToLoad;
        OnLoacalChanged?.Invoke();
    }

    public string Localize(string key)
    {
        return _localization.TryGetValue(key, out var value) ? value : $"%{key}%";
    }

    internal void SetLocale(string localeScale)
    {
        LoadLocal(localeScale);
    }
}
