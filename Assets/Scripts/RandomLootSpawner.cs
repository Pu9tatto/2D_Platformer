using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomLootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _guaranteedLoot;

    [Space, Header("GuaranteedLootBetween")]
    [SerializeField] private GameObject[] _firstVariantLoot;
    [SerializeField] private GameObject[] _secondVariantLoot;
    [SerializeField, Range(0,100)] private int _rateFirstLoot;

    [SerializeField] private LootObject[] _possibleLoot;

    [SerializeField] private float _force;

    private System.Random random = new System.Random();

    public void TrySpawnLoot()
    {
        if(_guaranteedLoot.Length > 0)
            SpawnGuaranteedLoot(_guaranteedLoot);

        if (_firstVariantLoot.Length > 0)
            SpawnGuaranteedLootBetween();

        if (_possibleLoot.Length > 0)
            SpawnPossibleLoot(_possibleLoot);
    }

    private void SpawnGuaranteedLoot(GameObject[] list)
    {
        foreach (GameObject obj in list)
            CreateLoot(obj);
    }

    private void SpawnGuaranteedLootBetween()
    {
        int rateBetween = random.Next(0,100);
        Debug.Log("RateBetween: " + rateBetween);
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
        int rate = random.Next(0,100);

        Debug.Log("rate: " + rate);

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
        var loot = Instantiate(go, transform.position, Quaternion.identity);
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
