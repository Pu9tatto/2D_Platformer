using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static OptionalDialogController;

public class OptionItemWidget : MonoBehaviour, IItemRenderer<OptionData> 
{
    [SerializeField] private Text _label;
    [SerializeField] private UnityEvent<OptionData> _onSelect;

    private OptionData _data;

    public void SetData(OptionData data, int index)
    {
        _data = data;
        _label.text = data.Text;
    }

    public void OnSelect()
    {
        _onSelect.Invoke(_data);
    }
}
