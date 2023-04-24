using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class ParalaxEffect : MonoBehaviour
    {
        [SerializeField] private float _effectValue;
        [SerializeField] private Transform _followTarget;

        private float _startX;

        private void Start()
        {
            if(_followTarget == null)
                _followTarget = Camera.main.transform;
            _startX = transform.position.x;
        }

        private void LateUpdate()
        {
            var currentPosiotion = transform.position;
            var deltaX = _followTarget.position.x * _effectValue;
            transform.position = new Vector3(_startX+deltaX, currentPosiotion.y, currentPosiotion.z);
        }
    }
}