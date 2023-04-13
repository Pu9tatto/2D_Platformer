using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _damping;

    private Vector3 _destination;
    private void LateUpdate()
    {
        _destination = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime*_damping);
    }
}
