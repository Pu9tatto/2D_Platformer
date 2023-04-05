using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _pointToTeleport;

    public void TeleportTarget(GameObject target)
    {
        target.transform.position = _pointToTeleport.position;
    }
}
