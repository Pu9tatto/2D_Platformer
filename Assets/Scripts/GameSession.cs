using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private HeroData _data;

    public HeroData Data => _data;

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

    private bool IsSession()
    {
        session = FindObjectOfType<GameSession>();
        return session != this;
    }
}
