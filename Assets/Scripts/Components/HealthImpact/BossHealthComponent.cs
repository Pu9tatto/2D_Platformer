using UnityEngine;

public class BossHealthComponent : HealthComponent
{
    private BossStarAI _bossAI;
    private BossPhase[] _bossPhases;
    private int _percentHealth;
    private int _currentPhase = 0;

    private void Awake()
    {
        _bossAI = GetComponent<BossStarAI>();
        _bossPhases = _bossAI.BossPhases;
    }

    protected override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        if (_currentPhase >= _bossPhases.Length - 1) return;
        _percentHealth = _health / _maxHealth * 100;
        if (_percentHealth < _bossPhases[_currentPhase + 1].PercentageHpToEnter)
        {
            _currentPhase++;
            _bossAI.SwitchPhase(_currentPhase);
        }
    }

}
