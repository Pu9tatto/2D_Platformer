using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent<GameObject> _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(_tag))
        {
            _action?.Invoke(other.gameObject);
        }
    }
}
