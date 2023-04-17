using UnityEngine;

public class StarAnimation : EnemyAnimation
{
    protected static readonly int MissKey = Animator.StringToHash("miss");
    protected static readonly int IsSpinKey = Animator.StringToHash("is-spin");
    protected static readonly int IsPrepareKey = Animator.StringToHash("is-prepare");



    public void MissAnticipation()
    {
        _animator.SetTrigger(MissKey);
    }

    public void SetSpin(bool isSpin)
    {
        _animator.SetBool(IsSpinKey, isSpin);
    }
    public void SetPrepare(bool isPrepare)
    {
        _animator.SetBool(IsPrepareKey, isPrepare);
    }

}



