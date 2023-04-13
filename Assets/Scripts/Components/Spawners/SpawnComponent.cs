using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;

    public void Spawn()
    {
        foreach (var prefab in _prefabs)
        {
            var tamplate = Instantiate(prefab, transform.position, Quaternion.identity);
            tamplate.transform.localScale = transform.lossyScale;
        }
    }
}