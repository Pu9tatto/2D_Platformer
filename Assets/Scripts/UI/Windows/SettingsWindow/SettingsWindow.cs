using UnityEngine;

public class SettingsWindow : AnimatedWindow
{
    [SerializeField] private AudioSettingWidget _music;
    [SerializeField] private AudioSettingWidget _sfx;

    protected override void Start()
    {
        base.Start();

        _music.SetModel(GameSettings.I.Music);
        _sfx.SetModel(GameSettings.I.Sfx);
    }
}
