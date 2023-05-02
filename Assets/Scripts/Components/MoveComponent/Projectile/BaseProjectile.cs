using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lifeTime;

    protected float _direction;
    protected Rigidbody2D _rigidbody;

    protected virtual void Start()
    {
        _direction = transform.lossyScale.x > 0 ? 1 : -1;
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);
    }
}
