using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroThrow : MonoBehaviour
{
    [InventoryId] [SerializeField] private string _throwDefoultId;
    [SerializeField] private SpawnComponent _throwSpawner;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private float _timeForMultiThrow;
    [SerializeField] private int _countMultiThrow;
    [SerializeField] private float _timeBetweenThrow;
    [SerializeField] private PlaysSoundsComponent _sounds;

    private float _startPressThrowTimer;
    private Inventory _inventory;
    private GameSession _session;

    private string _throwId;
    private int _projectileValue => _inventory.Count(_throwId);

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        _session = GameSession.Session;
    }

    public void PressThrow()
    {
        _startPressThrowTimer = Time.time;

        _throwId = _session.QuickInvetory.SelectedItem.Id;

        var selectedItem = DefsFacade.I.Items.Get(_throwId);
        if(!selectedItem.HasTag(ItemTag.Throwable))
        {
            _throwId = _throwDefoultId;
        }

        var throwableDef = DefsFacade.I.ThrowableItems.Get(_throwId);
        _throwSpawner.SetPrefab(throwableDef.Projectile);
    }

    public void DoThrow()
    {
        var minvalue = _throwId == "Sword"? 1: 0;
        if (_projectileValue <= minvalue) return;

        if(_projectileValue < _countMultiThrow)
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
        _throwSpawner.Spawn();
        _inventory.RemoveInInventoryData(_throwId, 1);
        _sounds.Play("Range");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
