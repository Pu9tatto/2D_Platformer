using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private HeroData _data;

    public HeroData Data => _data;
    private HeroData _save;

    private static GameSession session;
    public static GameSession Session => session;

    private void Awake()
    {
        if (IsSession())
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        Save();
    }

    private bool IsSession()
    {
        session = FindObjectOfType<GameSession>();
        return session != this;
    }

    public void Save()
    {
        _save = _data.Clone();
    }

    public void LoadLastSave()
    {
        _data = _save.Clone();
    }
}
