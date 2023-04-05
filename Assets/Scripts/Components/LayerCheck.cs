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

    private void Update()
    {
        IsTouchingLayer = CheckTouchingLayer();
    }

    public bool CheckTouchingLayer()
    {
        return _collider.IsTouchingLayers(_layer);
    }

}
