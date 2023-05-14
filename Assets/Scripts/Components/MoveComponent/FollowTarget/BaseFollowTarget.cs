using UnityEngine;


public class BaseFollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    protected Vector3 _destination;
    private void LateUpdate()
    {
        if (_target != null)
            Move();
    }
    protected virtual void Move()
    {
        _destination = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}
