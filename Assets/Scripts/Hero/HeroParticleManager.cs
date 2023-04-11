using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroParticleManager : MonoBehaviour
{
    [SerializeField] private SpawnComponent _footStepParticle;
    [SerializeField] private SpawnComponent _fallParticle;
    [SerializeField] private SpawnComponent _jumpParticle;
    [SerializeField] private SpawnComponent _attack1Particle;
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
