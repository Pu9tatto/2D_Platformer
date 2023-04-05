using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpened = false;
    private static readonly int IsOpenKey = Animator.StringToHash("is-open");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SwitchOpeningDoor()
    {
        _isOpened = !_isOpened;
        _animator.SetBool(IsOpenKey, _isOpened);
    }
}
