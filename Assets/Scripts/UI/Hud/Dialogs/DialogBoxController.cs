using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _container;
    [SerializeField] private Animator _animator;
    [Space]
    [SerializeField] private float _textSpeed = 0.1f;

    private static readonly int IsOPen = Animator.StringToHash("is-open");

    private DialogData _data;
    private int _currentSentence;
    private PlaysSoundsComponent _sounds;
    private Coroutine _typingRoutine;

    private void Start()
    {
        _sounds = GetComponent<PlaysSoundsComponent>();
    }
    public void ShowDialog(DialogData data)
    {
        _data = data;
        _currentSentence = 0;
        _text.text = string.Empty;

        _container.SetActive(true);
        _sounds.Play("open");
        _animator.SetBool(IsOPen, true);
    }
    private IEnumerator TypeDialogText()
    {
        _text.text = string.Empty;
        var sentences = _data.Sentences[_currentSentence];
        foreach (var letter in sentences)
        {
            _text.text += letter;
            _sounds.Play("typing");
            yield return new WaitForSeconds(_textSpeed);
        }

        _typingRoutine = null;
    }

    public void OnSkip()
    {
        if (_typingRoutine == null) return;

        StopTypeAnimation();
        _text.text = _data.Sentences[_currentSentence];
    }

    private void StopTypeAnimation()
    {
        if (_typingRoutine != null)
            StopCoroutine(_typingRoutine);
        _typingRoutine=null;
    }

    public void OnContinue()
    {
        StopTypeAnimation();
        _currentSentence++;

        var isDialogeCompleted = _currentSentence >= _data.Sentences.Length;
        if (isDialogeCompleted)
        {
            HideDialogBox();
        }
        else
        {
            OnStartDialogAnimation();
        }
    }

    private void HideDialogBox()
    {
        _animator.SetBool(IsOPen, false);
        _sounds.Play("close");
    }

    private void OnStartDialogAnimation()
    {
        _typingRoutine = StartCoroutine(TypeDialogText());
    }


    private void OnCloseAnimationComlete()
    {

    }
}
