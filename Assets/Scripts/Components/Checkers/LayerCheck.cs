using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private Collider2D _collider;
    public bool IsTouchingLayer { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_layer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_layer);
    }

    public bool CheckTouchingLayer()
    {
        return _collider.IsTouchingLayers(_layer);
    }

}
