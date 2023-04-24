using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingWidget : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _value;

    private FloatPresistentProperty _model;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();

    private void Start()
    {
        _trash.Retain(_slider.onValueChanged.Subscribe(OnSliderValueChanged));
    }

    public void SetModel(FloatPresistentProperty model)
    {
        _model = model;
        _trash.Retain(model.Subscribe(OnValueChanged));
        OnValueChanged(model.Value, model.Value);
    }
    private void OnSliderValueChanged(float value)
    {
        _model.Value = value;
    }

    private void OnValueChanged(float newValue, float oldValue)
    {
        var textValue = Mathf.Round(newValue * 100);
        _value.text = textValue.ToString();
        _slider.normalizedValue = newValue;
    }

    private void OnDestroy()
    {
        _trash.Dispose();
    }
}

