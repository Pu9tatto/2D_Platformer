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

    private Inventory _inventory;
    private float _startPressTHrowTimer;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public void PressThrow()
    {
        _startPressTHrowTimer = Time.time;
    }

    public void DoThrow()
    {
        var swordsValue = _inventory.GetSwordValue()-1;

        if (swordsValue <= 0) return;

        if(swordsValue< _countMultiThrow)
        {
            SingleThrow();
            return;
        }

        if (_startPressTHrowTimer + _timeForMultiThrow < Time.time)
            StartCoroutine(MultiThrow());
        else
            SingleThrow();
    }

    private void SingleThrow()
    {
        _projectile.Spawn();
        _inventory.ThrowSwords();

        Debug.Log("1 sword throw");
    }

    private IEnumerator MultiThrow()
    {
        for (int i =0; i < _countMultiThrow; i++)
        {
            _projectile.Spawn();
            _inventory.ThrowSwords();
            yield return new WaitForSeconds(_timeBetweenThrow);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
