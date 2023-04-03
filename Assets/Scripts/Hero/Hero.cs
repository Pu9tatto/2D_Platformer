using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if(_direction != Vector2.zero)
        {
            var newXPosition = transform.position.x+_direction.x *_speed* Time.deltaTime;
            var newYPosition = transform.position.y + _direction.y * _speed * Time.deltaTime;
            transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
        }
    }
}
