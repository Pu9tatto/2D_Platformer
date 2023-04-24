using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizeText : MonoBehaviour
{
    [SerializeField] private string _key;
    [SerializeField] private bool _capitalize;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        
        LocalizationManager.I.OnLoacalChanged += OmLocalChanged;
        Localize();
    }
    private void OmLocalChanged()
    {
        Localize();
    }

    private void Localize()
    {
        var localized = LocalizationManager.I.Localize(_key);
        _text.text = _capitalize ? localized.ToUpper() : localized;
    }

    private void OnDestroy()
    {
        LocalizationManager.I.OnLoacalChanged -= OmLocalChanged;
    }
}
