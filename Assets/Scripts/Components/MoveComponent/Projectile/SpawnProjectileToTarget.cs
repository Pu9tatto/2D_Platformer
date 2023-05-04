using UnityEngine;

public class SpawnProjectileToTarget : SpawnComponent
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lifeTime;
    [SerializeField] private Transform _target;

    public override void Spawn()
    {
        if( _target != null)
        {
            var direction = GetDirection(_target).normalized;
            var tamplate = Instantiate(_projectile, transform.position, Quaternion.identity);
            tamplate.transform.localScale = transform.lossyScale;
            var force = direction * _speed;
            if (tamplate.TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
    private Vector2 GetDirection(Transform target)
    {
        return target.position - transform.position;
    }

    public void SetTarget(GameObject target)
    {
        if(_target == null)
            _target= target.transform;
    }
}
