using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class VerticalLevitationComponent : MonoBehaviour
{
    [SerializeField] private float _frequancy = 5f;
    [SerializeField] private float _amplitude = 0.1f;
    [SerializeField] private bool _randomize;

    private float _originalY;
    private float _seed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _originalY = _rigidbody.position.y;
        if (_randomize)
        {
            _seed = Random.value * Mathf.PI * 2;
        }
    }

    private void FixedUpdate()
    {
        var position = _rigidbody.position;
        position.y = _originalY + Mathf.Sin(_seed +Time.time*_frequancy) * _amplitude;
        _rigidbody.MovePosition(position);
    }

}
