using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private float _sectorAngle = 60;
    [SerializeField] private float _sectorRotation;

    [SerializeField] private float _waitTime = 0.1f;
    [SerializeField] private float _speed = 6;

    [SerializeField] private bool _isTimeDestroy = false;
    [SerializeField] private float _lifeTime = 3;

    private Coroutine _coroutine;

    public void StartDrop(List<GameObject> items)
    {
        TryStopCoroutine();

        _coroutine = StartCoroutine(StartSpawn(items));
    }

    private IEnumerator StartSpawn(List<GameObject> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Spawn(items[i]);
        }

        yield return new WaitForSeconds(_waitTime);
    }

    [ContextMenu("Spawn")]
    private void Spawn(GameObject item)
    {
        var instance = Instantiate(item, transform.position, Quaternion.identity);
        if(_isTimeDestroy)
        {
            Destroy(instance, _lifeTime);
        }
        if(instance.TryGetComponent(out Rigidbody2D rigidbody))
        {
            var randomAngle = Random.Range(0, _sectorAngle);
            var forceVector = AngleToVectorInSector(randomAngle);
            rigidbody.AddForce(forceVector * _speed, ForceMode2D.Impulse);
        }
    }

    private void OnDisable()
    {
        TryStopCoroutine();
    }

    private void OnDestroy()
    {
        TryStopCoroutine();
    }

    private Vector2 AngleToVectorInSector(float angle)
    {
        var angleMiddleDelta = (180 - _sectorAngle - _sectorRotation) / 2;
        return GetUnitOnCircle(angle + angleMiddleDelta);
    }
    private void TryStopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private Vector3 GetUnitOnCircle(float angleDegrees)
    {
        var angleRadians = angleDegrees * Mathf.PI / 180.0f;

        var x = MathF.Cos(angleRadians);
        var y = MathF.Sin(angleRadians);

        return new Vector3(x, y, 0);
    }

    private void OnDrawGizmos()
    {
        var position = transform.position;

        var middleAngleDelta = (180 - _sectorAngle - _sectorRotation) / 2;
        var rightBound = GetUnitOnCircle(middleAngleDelta);
        Handles.DrawLine(position, position + rightBound);

        var leftBound = GetUnitOnCircle(middleAngleDelta + _sectorAngle);
        Handles.DrawLine(position, position + leftBound);

        Handles.color = new Color(1, 1, 1, 0.1f);
        Handles.DrawSolidArc(position, Vector3.forward, rightBound, _sectorAngle, 1f);
    }
}
