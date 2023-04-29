using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cannon : MonoBehaviour
{
    [SerializeField] private PoolObjectSpawnComponent _ballSpawner;
    [SerializeField] private SpawnComponent _fireParticleSpawner;
    [SerializeField] private Cooldown _ballSpawnCooldawn;
    [SerializeField] private PlaySfxSound _fireSfx;

    private Animator _animator;

    private static readonly int setFire = Animator.StringToHash("fire");


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TryFire()
    {
        if (_ballSpawnCooldawn.IsReady())
        {
            _ballSpawnCooldawn.Reset();
            _animator.SetTrigger(setFire);
            _fireSfx.Play();
        }
    }
    private void Fire()
    {
        _ballSpawner.Spawn();
        _fireParticleSpawner.Spawn();
    }
}
