using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;

    public AudioClip introSound;
    public AudioClip fireSound;
    public AudioClip hitSound;
    public AudioClip deadSound;
    public AudioClip winSound;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    public void PlayIntroSound()
    {
        _AudioSource.PlayOneShot(introSound);
    }

    public void PlayFireSound()
    {
        _AudioSource.PlayOneShot(fireSound);
    }

    public void PlayHitSound()
    {
        _AudioSource.PlayOneShot(hitSound);
    }

    public void PlayDeadSound()
    {
        _AudioSource.PlayOneShot(deadSound);
    }

    public void PlayWinSound()
    {
        _AudioSource.PlayOneShot(winSound);
    }

    public void StopSound()
    {
        _AudioSource.Stop();
    }
}