using UnityEngine;
using UnityEngine.Events;

public class EnterColiisionComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _layerEnter;
    [SerializeField] private UnityEvent<GameObject> _actionEnter;
    [SerializeField] private LayerMask _layerStay;
    [SerializeField] private UnityEvent<GameObject> _actionStay;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.IsInLayer(_layerEnter))
        {
            _actionEnter?.Invoke(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.IsInLayer(_layerStay))
        {
            _actionStay?.Invoke(other.gameObject);
        }
    }
}

