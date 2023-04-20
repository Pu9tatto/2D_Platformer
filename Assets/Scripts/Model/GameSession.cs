using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private HeroData _data;

    public HeroData Data => _data;
    private HeroData _save;

    private readonly CompositeDisposeable _trash = new CompositeDisposeable();
    public QuickInvetoryModel QuickInvetory { get; private set; }

    private static GameSession session;
    public static GameSession Session => session;

    private void Awake()
    {
        LoadHud();

        if (IsSession())
        {
            Destroy(gameObject);
        }
        else
        {
            Save();
            InitModels();
            DontDestroyOnLoad(this);
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

        _trash.Dispose();
        InitModels();
    }
    private void OnDestroy()
    {
        _trash.Dispose();
    }
}
