using UnityEngine;

public class ParabolProjectile : BaseProjectile
{
    [SerializeField] private float _ySpeed;
    [SerializeField, Range(0,90)] private float _angle;
    [SerializeField] private float _gravity = 10;

    [SerializeField] private float _rotetionSpeed;

    private float _time;
    protected override void Start()
    {
        base.Start();
        _angle = _angle / 180 * Mathf.PI;
    }

    private void FixedUpdate()
    {
        var position = _rigidbody.position;
        position.x += _direction * _speed * _time * Mathf.Cos(_angle);
        position.y += _ySpeed * _time*Mathf.Sin(_angle) - _gravity*_time*_time/2;
        _rigidbody.MovePosition(position);

        _rigidbody.MoveRotation(_time* _rotetionSpeed);
        _time += Time.fixedDeltaTime;
    }
}
