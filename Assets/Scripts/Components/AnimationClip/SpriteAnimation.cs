using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _onComplete;

    private SpriteRenderer _renderer;

    private float _secondsPerFrame;
    private float _nextFrameTime;

    private int _currentSpriteIndex;
    private bool _isPlaying = true;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _secondsPerFrame = 1f / _frameRate;
    }

    private void OnEnable()
    {
        enabled = _isPlaying;
        StartAnimation();
    }
    private void OnBecameVisible()
    {
        enabled = _isPlaying;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void StartAnimation()
    {
        _nextFrameTime = Time.time;
        _isPlaying = true;
        _currentSpriteIndex = 0;
    }
    private void Update()
    {
        if(_nextFrameTime < Time.time)
        {
            _nextFrameTime += _secondsPerFrame;
            SetNextSprite();
        }
        
    }

    private void SetNextSprite()
    {
        if (_currentSpriteIndex >= _sprites.Length)
        {
            if (_loop)
            {
                _currentSpriteIndex = 0;
            }
            else
            {
                enabled = false;
                _onComplete?.Invoke();
                return;
            }
        }
        _renderer.sprite = _sprites[_currentSpriteIndex];
        _currentSpriteIndex++;
    }
}
