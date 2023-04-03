using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public bool CheckTouchingLayer()
    {
        return _collider.IsTouchingLayers(_layer);
    }

}
