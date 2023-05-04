using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _acceleration;

    private Hero _hero;
    private float _deltaSpeed;
    private float _direction;
    private bool _isSetSail;

    private void Start()
    {
        _hero = FindAnyObjectByType<Hero>();
    }

    private void FixedUpdate()
    {
        Move();
        SpeedUp();
    }


    private void Move()
    {
        if (_deltaSpeed <= 0) return;
        transform.position += Vector3.right * _speed * _deltaSpeed;
    }

    public void TransitSail()
    {
        _isSetSail = !_isSetSail;
        _direction = _isSetSail ? 1 : -1;
    }

    private void SpeedUp()
    {
        if (_deltaSpeed < 0)
        {
            _deltaSpeed = 0;
            return;
        }
        if (_deltaSpeed > 1)
        {
            _deltaSpeed = 1;
            return;
        }
        _deltaSpeed += _direction * _acceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TryAddItemInCollision loot))
        {
            loot.TryAddItem(_hero.gameObject);
        }
    }
}
