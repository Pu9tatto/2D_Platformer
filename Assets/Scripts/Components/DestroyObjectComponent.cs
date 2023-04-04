using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectForDestroy;

    public void DestroyToObject()
    {
        Destroy(_objectForDestroy);
    }
}
