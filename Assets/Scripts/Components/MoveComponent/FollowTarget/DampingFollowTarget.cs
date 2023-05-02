using UnityEngine;

public class DampingFollowTarget : BaseFollowTarget
{
    [SerializeField] private float _damping;
    protected override void Move()
    {
        base.Move();
        transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _damping);
    }
}
