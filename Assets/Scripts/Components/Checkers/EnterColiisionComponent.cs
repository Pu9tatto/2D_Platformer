using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterColiisionComponent : MonoBehaviour
{
    [SerializeField] private string[] _tags;
    [SerializeField] private UnityEvent<GameObject> _action;


    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var tag in _tags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                _action?.Invoke(other.gameObject);
            }
        }
    }
}

