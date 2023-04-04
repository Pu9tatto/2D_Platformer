using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SearchService;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(_tag))
        {
            _action?.Invoke();
        }
    }
}
