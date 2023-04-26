using System.Collections;
using UnityEngine;


public class PlaySfxSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _playOnAwake;
    private AudioSource _source;

    private void OnEnable()
    {
        if (_playOnAwake)
            Play();
    }

    public void Play()
    {
        if (_source == null)
            _source = AudioUtils.FindSfxSource();

        _source.PlayOneShot(_clip);
    }
}
