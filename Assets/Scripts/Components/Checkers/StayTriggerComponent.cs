using UnityEngine;
using UnityEngine.Events;

public class StayTriggerComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private UnityEvent<GameObject> _action;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.IsInLayer(_layer))
        {
            _action?.Invoke(other.gameObject);
        }
    }
}
