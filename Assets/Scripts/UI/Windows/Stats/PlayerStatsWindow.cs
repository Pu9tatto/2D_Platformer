using UnityEngine;

public class PlayerStatsWindow : AnimatedWindow
{
    [SerializeField] private Transform _statsContainer;
    [SerializeField] private StatWidget _prefab;

    private DataGroup<StatDef, StatWidget> _dataGroup;

    private GameSession _session;
    private readonly CompositeDisposeable _trash = new CompositeDisposeable();

    protected override void Start()
    {
        base.Start();

        _dataGroup = new DataGroup<StatDef, StatWidget>(_prefab, _statsContainer);

        _session = GameSession.Session;
        _trash.Retain(_session.StatsLevelModel.Subscribe(OnStatsChanged));

        OnStatsChanged();
    }

    private void OnStatsChanged()
    {
        var stats = DefsFacade.I.Player.Stats;
        _dataGroup.SetData(stats);

        
    }

    private void OnDestroy()
    {
        _trash.Dispose();
    }
}

