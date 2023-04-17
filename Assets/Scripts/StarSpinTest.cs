using System.Collections;
using UnityEngine;

public class StarSpinTest : MonoBehaviour
{
    [SerializeField] private float _speedSpin;
    [SerializeField] private Cooldown _spinDelay;

    [SerializeField] private float _gravity;
    private Rigidbody2D _rigidbody;

    private Vector3 _direction;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gravity = -Physics2D.gravity.y;
    }

    private void FixedUpdate()
    {

    }

    public void SpinToTarget(GameObject go)
    {
        _rigidbody.velocity = Vector3.zero;
        _direction = (go.transform.position - transform.position).normalized;
        StartCoroutine(Co_spin());
    }

    private IEnumerator Co_spin()
    {
        _spinDelay.Reset();
        while (!_spinDelay.IsReady())
        {
            _rigidbody.MovePosition(transform.position + _direction*_speedSpin*Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
