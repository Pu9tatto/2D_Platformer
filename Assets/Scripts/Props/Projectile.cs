using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private float _direction;
    private float _burnTime;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _direction = transform.lossyScale.x > 0 ? 1 : -1;
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);
    }


    private void FixedUpdate()
    {
        var position = _rigidbody.position;
        position.x += _speed * _direction;
        _rigidbody.MovePosition(position);
    }
}
