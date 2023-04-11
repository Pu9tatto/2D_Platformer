using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroParticleManager : MonoBehaviour
{
    [SerializeField] private PoolObjectSpawnComponent _footStepParticle;
    [SerializeField] private PoolObjectSpawnComponent _fallParticle;
    [SerializeField] private PoolObjectSpawnComponent _jumpParticle;
    [SerializeField] private PoolObjectSpawnComponent _attack1Particle;
    [SerializeField] private ParticleSystem _burstCoinOnHitParticle;
    [SerializeField] private int _coinsForDrop;

    public void CreateAttack1Particle()
    {
        _attack1Particle.Spawn();
    }

    public void CreateFootStepParticle()
    {
        _footStepParticle.Spawn();
    }
    public void CreateJumpParticle()
    {
        _jumpParticle.Spawn();
    }

    public void CreateHightFallParticle()
    {
        _fallParticle.Spawn();
    }
}
