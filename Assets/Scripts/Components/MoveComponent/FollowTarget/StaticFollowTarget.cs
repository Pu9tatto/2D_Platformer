public class StaticFollowTarget : BaseFollowTarget
{
    protected override void Move()
    {
        base.Move();
        transform.position = _destination;
    }
}
