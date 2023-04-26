using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float[] _durations;
    [SerializeField] private Vector3[] _deltaTargetTransform;

    public void StartMove()
    {
        StartCoroutine(Co_Move());
    }

    public IEnumerator Co_Move()
    {
        for (int i = 0; i < _durations.Length; i++)
        {
            float _duration = _durations[i];
            Vector3 _delta = _deltaTargetTransform[i];
            float progress = 0;
            Vector3 finishPoint = _target.transform.position + _delta;
            while (progress < _duration)
            {
                _target.transform.position = Vector3.Lerp(_target.transform.position, finishPoint, progress / _duration);
                progress += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

    }
}
