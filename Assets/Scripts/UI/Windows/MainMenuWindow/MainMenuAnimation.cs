using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAnimation : AnimatedWindow
{
    [SerializeField] private string StartLevel = "HudScene";
    private Action _closeAction;

    public void OnShowSettings()
    {
        WindowUtils.CreateWindow("UI/SettingsWindow");
    }

    public void OnStartGame()
    {
        _closeAction = () => { SceneManager.LoadScene(StartLevel); };
        Close();
    }

    public void OnLanguges()
    {
        WindowUtils.CreateWindow("UI/LocalizationWindow");
    }

    public void OnExit()
    {
        _closeAction = () =>
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        };
        Close();
    }

    public override void OnCloseAnimationComplet()
    {
        base.OnCloseAnimationComplet();
        _closeAction?.Invoke();        
    }
}
