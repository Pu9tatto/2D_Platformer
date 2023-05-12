using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private HeroData _data;
    [SerializeField] private string _defaultCheckpoint;
    

    public HeroData Data => _data;
    private HeroData _save;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();
    public QuickInvetoryModel QuickInvetory { get; private set; }

    private List<string> _removedItems = new List<string>();
    private List<string> _savedRemovedItems;
    private readonly List<string> _checkpoints = new List<string>();


    private static GameSession session;
    public static GameSession Session => session;


    private void Awake()
    {
        var existsSession = GetExitSession();
        if (existsSession != null)
        {
            existsSession.StartSession(_defaultCheckpoint);
            Destroy(gameObject);
        }
        else
        {
            Save();
            InitModels();
            DontDestroyOnLoad(this);
            StartSession(_defaultCheckpoint);
        }
    }
    private void Start()
    {
        Save();
    }
    private void StartSession(string defaultCheckpoint)
    {
        SetChecked(defaultCheckpoint);
        LoadHud();
        SpawnHero();
    }

    private void SpawnHero()
    {
        var checkpoints = FindObjectsOfType<CheckPointComponent>();
        var lastCheckpoint = _checkpoints.Last();
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.Id == lastCheckpoint)
            {
                checkpoint.SpawnHero();
                break;
            }
        }
    }

    private void InitModels()
    {
        QuickInvetory = new QuickInvetoryModel(_data);
        _trash.Retain(QuickInvetory);
    }

    private void LoadHud()
    {
        SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
    }

    private GameSession GetExitSession()
    {
        session = FindObjectOfType<GameSession>();

        if (session != this)
            return session;

        return null;
    }

    public void Save()
    {
        _save = _data.Clone();
        _savedRemovedItems = new List<string>(_removedItems);
    }

    public void LoadLastSave()
    {
        _data = _save.Clone();

        _trash.Dispose();
        InitModels();
    }

    public bool IsChecked(string id)
    {
        return _checkpoints.Contains(id);
    }
    public void SetChecked(string id)
    {
        if (!_checkpoints.Contains(id))
        {
            Save();
            _checkpoints.Add(id);
        }
    }

    private void OnDestroy()
    {
        _trash.Dispose();
    }

    public bool RestoreSrate(string itenId)
    {
        return _savedRemovedItems.Contains(itenId);
    }

    public void StoreState(string itenId)
    {
        if(!_removedItems.Contains(itenId))
            _removedItems.Add(itenId);
    }
}
