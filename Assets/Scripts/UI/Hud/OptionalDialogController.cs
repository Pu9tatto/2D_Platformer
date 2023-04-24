using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionalDialogController : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private Text _contentText;
    [SerializeField] private Transform _optionsContainer;
    [SerializeField] private OptionItemWidget _prefab;

    private DataGroup<OptionData, OptionItemWidget> _dataGroup;

    private void Start()
    {
        _dataGroup = new DataGroup<OptionData, OptionItemWidget>(_prefab, _optionsContainer);
    }

    public void Show(OptionalDialogData data)
    {
        _content.SetActive(true);
        _contentText.text = data.DialogeText;

        _dataGroup.SetData(data.Options);
    }

    public void OnOptionSelecrted(OptionData selectedOption)
    {
        selectedOption.OnSelect.Invoke();
        _content.SetActive(false);
    }

    [Serializable]
    public class OptionalDialogData 
    {
        public string DialogeText;
        public OptionData[] Options;
    }

    [Serializable]
    public class OptionData
    {
        public string Text;
        public UnityEvent OnSelect;
    }

}

