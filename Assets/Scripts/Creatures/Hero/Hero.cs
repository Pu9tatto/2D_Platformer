using System.Collections;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _hitInvulerableTime;

    private bool _isInvulnerable = false;

    public bool IsInvulnerable => _isInvulnerable;

    public void GetInvulnerable()
    {
        StartCoroutine(Co_GetInvulnerable(_hitInvulerableTime));
    }

    private IEnumerator Co_GetInvulnerable(float time)
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(time);
        _isInvulnerable = false;
    }
}
