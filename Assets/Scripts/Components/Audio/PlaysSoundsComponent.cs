using System;
using UnityEngine;

public class PlaysSoundsComponent : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioData[] _sounds;

    public void Play(string id)
    {
        if (_source == null)
            _source = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();

        foreach (var audioData in _sounds)
        {
            if (audioData.Id != id) continue;

            _source.PlayOneShot(audioData.Clip);
            break;
        }
    }


    [Serializable]
    public class AudioData 
    {
        [SerializeField] private string _id;
        [SerializeField] private AudioClip _clip;

        public string Id=> _id;
        public AudioClip Clip => _clip;
    }

}
