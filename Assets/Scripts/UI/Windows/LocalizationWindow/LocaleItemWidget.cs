using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LocaleItemWidget : MonoBehaviour, IItemRenderer<LocaleInfo>
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _selector;
    [SerializeField] private UnityEvent<string> _onSelected;

    private LocaleInfo _data;

    private void Start()
    {
        LocalizationManager.I.OnLoacalChanged += UpdateSelection;
    }


    public void SetData(LocaleInfo localeKey, int index)
    {
        _data = localeKey;
        UpdateSelection();
        _text.text = localeKey.LocaleId.ToUpper();
    }
    private void UpdateSelection()
    {
        var isSelected = LocalizationManager.I.LocalKey == _data.LocaleId;
        _selector.SetActive(isSelected);
    }

    public void OnSelected()
    {
        _onSelected?.Invoke(_data.LocaleId);
    }

    private void OnDestroy()
    {
        LocalizationManager.I.OnLoacalChanged -= UpdateSelection;
    }
}
public class LocaleInfo
{
    public string LocaleId;
}
