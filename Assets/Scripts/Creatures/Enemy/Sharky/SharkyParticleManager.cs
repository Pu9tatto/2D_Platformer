using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkyParticleManager : MonoBehaviour
{
    [SerializeField] private PoolObjectSpawnComponent _attackParticle;
    public void CreateAttack1Particle()
    {
        _attackParticle.Spawn();
    }
}
