using UnityEngine;

[CreateAssetMenu(menuName = "Defs/GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private FloatPresistentProperty _music;
    [SerializeField] private FloatPresistentProperty _sfx;

    public FloatPresistentProperty Music => _music;
    public FloatPresistentProperty Sfx => _sfx;



    private static GameSettings _instance;
    public static GameSettings I => _instance == null ? LoadGameSettings() : _instance;

    private static GameSettings LoadGameSettings()
    {
        return _instance = Resources.Load<GameSettings>("GameSettings");
    }

    private void OnEnable()
    {
        _music = new FloatPresistentProperty(1, SoundSetting.Music.ToString());
        _sfx = new FloatPresistentProperty(1, SoundSetting.Sfx.ToString());
    }

    private void OnValidate()
    {
        Music.Validate();
        Sfx.Validate();
    }
}
public enum SoundSetting
{
    Music,
    Sfx
}
