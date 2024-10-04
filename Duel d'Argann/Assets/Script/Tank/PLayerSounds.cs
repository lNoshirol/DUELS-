using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSounds : MonoBehaviour
{
    private AudioSource _AudioSource;

    [SerializeField] AudioClip _fireSound;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }
}
