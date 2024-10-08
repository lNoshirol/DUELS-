using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSounds : MonoBehaviour
{
    private AudioSource _AudioSource;

    [SerializeField] AudioClip _introSound;
    [SerializeField] AudioClip _fireSound;
    [SerializeField] AudioClip _hitSound;
    [SerializeField] AudioClip _deadSound;
    [SerializeField] AudioClip _winSund;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    public void PlayIntroSound()
    {
        _AudioSource.PlayOneShot(_introSound);
    }

    public void PlayFireSound()
    {
        _AudioSource.PlayOneShot(_fireSound);
    }

    public void PlayHitSound()
    {
        _AudioSource.PlayOneShot(_hitSound);
    }

    public void PlayDeadSound()
    {
        _AudioSource.PlayOneShot(_deadSound);
    }

    public void PlayWinSound()
    {
        _AudioSource.PlayOneShot(_winSund);
    }
}