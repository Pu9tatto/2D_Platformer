﻿using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Throwable", fileName = "Throwable")]
public class ThrowableRepository : RepositoryDef<ThrowableDef>
{

}
[Serializable]
public struct ThrowableDef : IHaveId
{
    [InventoryId][SerializeField] private string _id;
    [SerializeField] private GameObject _projectile;

    public string Id => _id;
    public GameObject Projectile => _projectile;
}

