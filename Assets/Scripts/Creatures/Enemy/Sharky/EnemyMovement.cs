public class EnemyMovement : CreaturesMovement
{
    private PlaysSoundsComponent _sounds;

    protected override void Awake()
    {
        base.Awake();
        _sounds = GetComponent<PlaysSoundsComponent>();
    }

    public override void Attack()
    {
        base.Attack();
        _sounds?.Play("Attack");
    }
}
