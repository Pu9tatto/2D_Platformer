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
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
