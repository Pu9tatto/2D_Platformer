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

    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

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

    public void BurstCoinOnHit()
    {
        if (_inventory.GetCoinsValue() > 0)
        {
            var burstCount = _burstCoinOnHitParticle.emission.GetBurst(0);
            burstCount.count = _inventory.DropCoins(_coinsForDrop);
            _burstCoinOnHitParticle.emission.SetBurst(0, burstCount);
            _burstCoinOnHitParticle.Play();
        }
    }
}
