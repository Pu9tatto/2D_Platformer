using UnityEngine;

public class CrabAnimation : EnemyAnimation
{
    protected static readonly int MissKey = Animator.StringToHash("miss");

    public void MissAnticioation()
    {
        _animator.SetTrigger(MissKey);
    }
}
