using UnityEngine;

public class EnemyParticleManager : MonoBehaviour
{
    [SerializeField] private PoolObjectSpawnComponent _attackParticle;
    public void CreateAttackParticle()
    {
        _attackParticle.Spawn();
    }
}
