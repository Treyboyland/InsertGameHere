using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    public class PlayRandomClip : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip[] _clips;

        public void Play()
        {
            _audioSource.Stop();
            _audioSource.clip = _clips[Random.Range(0, _clips.Length)];
            _audioSource.Play();
        }
    }
}