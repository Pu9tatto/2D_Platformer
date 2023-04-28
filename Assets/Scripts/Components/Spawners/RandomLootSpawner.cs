using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class RandomLootSpawner : MonoBehaviour
{
    [SerializeField] private bool _startOnEnable;
    [Space]
    [SerializeField] private GameObject[] _guaranteedLoot;

    [Space, Header("GuaranteedLootBetween")]
    [SerializeField] private GameObject[] _firstVariantLoot;
    [SerializeField] private GameObject[] _secondVariantLoot;
    [SerializeField, Range(0,100)] private int _rateFirstLoot;

    [SerializeField] private LootObject[] _possibleLoot;

    [SerializeField] private UnityEvent<List<GameObject>> _onRandomCalculated;
    private List<GameObject> _loots = new List<GameObject>();

    private void OnEnable()
    {
        if (_startOnEnable)
        {
            RandomCalculate();
        }
    }

    [ContextMenu("Calculate")]
    public void RandomCalculate()
    {
        if(_guaranteedLoot.Length > 0)
            SpawnGuaranteedLoot(_guaranteedLoot);

        if (_firstVariantLoot.Length > 0)
            SpawnGuaranteedLootBetween();

        if (_possibleLoot.Length > 0)
            SpawnPossibleLoot(_possibleLoot);

        _onRandomCalculated?.Invoke(_loots);
        _loots.Clear();
    }

    private void SpawnGuaranteedLoot(GameObject[] list)
    {
        foreach (GameObject obj in list)
            _loots.Add(obj);
    }

    private void SpawnGuaranteedLootBetween()
    {
        int rateBetween = Random.Range(0,100);
        if (_rateFirstLoot  > rateBetween)
        {
            foreach(GameObject obj in _firstVariantLoot)
            {
                CreateLoot(obj);
            }
        }
        else
        {
            foreach (GameObject obj in _secondVariantLoot)
            {
                CreateLoot(obj);
            }
        }       
    }
    private void SpawnPossibleLoot(LootObject[] list)
    {
        int rate = Random.Range(0,100);

        foreach (LootObject obj in _possibleLoot)
        {
            if (obj.LootRate > rate)
            {
                CreateLoot(obj.Prefab);
            }
        }
    }
    private void CreateLoot(GameObject go)
    {
        _loots.Add(go);
    }
}

[Serializable]
public class LootObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField, Range(0, 100)] private int _lootRate;

    public GameObject Prefab => _prefab;
    public float LootRate => _lootRate;   
}
