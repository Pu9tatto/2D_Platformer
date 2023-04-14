using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroThrow : MonoBehaviour
{
    [SerializeField] private SpawnComponent _projectile;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private float _timeForMultiThrow;
    [SerializeField] private int _countMultiThrow;
    [SerializeField] private float _timeBetweenThrow;

    private float _startPressThrowTimer;
    private Inventory _inventory;

    private int _swordsValue => _inventory.Count("Sword");


    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public void PressThrow()
    {
        _startPressThrowTimer = Time.time;
    }

    public void DoThrow()
    {
        if (_swordsValue <= 1) return;

        if(_swordsValue < _countMultiThrow)
        {
            SingleThrow();
            return;
        }

        if (_startPressThrowTimer + _timeForMultiThrow < Time.time)
            StartCoroutine(MultiThrow());
        else
            SingleThrow();
    }

    private void SingleThrow()
    {
        _projectile.Spawn();
        _inventory.RemoveInInventoryData("Sword", 1);

    }

    private IEnumerator MultiThrow()
    {
        for (int i =0; i < _countMultiThrow; i++)
        {
            _projectile.Spawn();
            _inventory.RemoveInInventoryData("Sword", 1);
            yield return new WaitForSeconds(_timeBetweenThrow);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
