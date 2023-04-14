using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroThrow : MonoBehaviour
{
    [InventoryId] [SerializeField] private string _throwId;
    [SerializeField] private SpawnComponent _projectile;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private float _timeForMultiThrow;
    [SerializeField] private int _countMultiThrow;
    [SerializeField] private float _timeBetweenThrow;
    [SerializeField] private PlaysSoundsComponent _sounds;

    private float _startPressThrowTimer;
    private Inventory _inventory;

    private int _swordsValue => _inventory.Count(_throwId);

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
            Shot();
            return;
        }

        if (_startPressThrowTimer + _timeForMultiThrow < Time.time)
            StartCoroutine(MultiThrow());
        else
            Shot();
    }

    private IEnumerator MultiThrow()
    {
        for (int i =0; i < _countMultiThrow; i++)
        {
            Shot();
            yield return new WaitForSeconds(_timeBetweenThrow);
        }
    }

    private void Shot()
    {
        _projectile.Spawn();
        _inventory.RemoveInInventoryData(_throwId, 1);
        _sounds.Play("Range");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
