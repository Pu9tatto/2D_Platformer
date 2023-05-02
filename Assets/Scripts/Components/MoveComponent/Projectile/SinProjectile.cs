using UnityEngine;

public class SinProjectile : BaseProjectile
{
    [SerializeField] private float _frequancy = 1f;
    [SerializeField] private float _amplitude = 1f;
    [SerializeField] private float _xOffer = -1.5f;
    [SerializeField] private float _yOffer = 1f;


    private float _originalY;
    private float _time;

    protected override void Start()
    {
        base.Start();
        _originalY = _rigidbody.position.y;
    }

    private void FixedUpdate()
    {
        var position = _rigidbody.position;
        position.x += _direction * _speed;
        position.y = _originalY + Mathf.Sin(_time * _frequancy+_xOffer) * _amplitude+_yOffer;
        _rigidbody.MovePosition(position);
        _time += Time.fixedDeltaTime;
    }
}
