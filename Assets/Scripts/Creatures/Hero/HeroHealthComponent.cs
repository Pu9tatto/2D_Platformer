using UnityEngine;

public class HeroHealthComponent : HealthComponent
{
    private Hero _hero;
    private HeroData _data;

    protected override void Start()
    {
        _hero = GetComponent<Hero>();
        _data = GameSession.Session.Data;
        _health = _data.Hp.Value;
        _maxHealth = DefsFacade.I.Player.MaxHealth;
        if(_health > _maxHealth ) 
            _health = _maxHealth;
    }

    public override void ChangeHealth(int value)
    {
        base.ChangeHealth(value);
        _data.Hp.Value = _health;
    }
    protected override void TakeDamage(int value)
    {
        if (!_hero.IsInvulnerable)
        {
            base.TakeDamage(value);
            _hero.GetInvulnerable();
        }
    }

    public void OnDie()
    {
        _data.Inventory.Remove("Hat", 1);

        var window = Resources.Load<LoseWindow>("UI/LoseWindow");
        var canvas = FindObjectOfType<UIContainerWindows>();
        var loseWindow = Instantiate(window, canvas.transform);

        if (_data.Inventory.GetCount("Hat") <= 0)
            loseWindow.DeactivateRestart();
    }
}
