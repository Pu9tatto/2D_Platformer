using System;
using UnityEngine;
public class StatsLevelModel : IDisposable
{
    private readonly HeroData _data;
    public event Action OnChanged;

    public StatsLevelModel(HeroData data)
    {
        _data = data;
    }

    public IDisposable Subscribe(Action call)
    {
        OnChanged += call;
        return new ActionDisposable(() => OnChanged -= call);
    }

    public void LevelUp(StatId id)
    {
        var def = DefsFacade.I.Player.GetStat(id);
        var nextLevel = GetLevel(id) + 1;
        if (def.Levels.Length <= nextLevel) return;

        var price = def.Levels[nextLevel].Price;
        if (!_data.Inventory.IsEnough(price)) return;

        _data.Inventory.Remove("Coin", price);
        _data.StatsLevel.LevelUp(id);

        OnChanged?.Invoke();
    }

    public float GetValue(StatId id, int level = -1)
    {
        return GetLevelDef(id, level).Value;
    }

    public StatLevel GetLevelDef(StatId id, int level = -1)
    {
        if (level == -1) level = GetLevel(id);
        var def = DefsFacade.I.Player.GetStat(id);
        return def.Levels[GetLevel(id)];
    }

    public int GetLevel(StatId id) => _data.StatsLevel.GetLevel(id);
    public void Dispose()
    {

    }
}
