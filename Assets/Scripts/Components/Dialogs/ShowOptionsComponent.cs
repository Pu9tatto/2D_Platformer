using System.Collections;
using UnityEngine;
using static OptionalDialogController;

public class ShowOptionsComponent : MonoBehaviour
{
    [SerializeField] private OptionalDialogData _data;

    private OptionalDialogController _dialogBox;

    public void Show()
    {
        if( _dialogBox == null )
            _dialogBox = FindAnyObjectByType<OptionalDialogController>();

        _dialogBox.Show(_data);
    }

}
