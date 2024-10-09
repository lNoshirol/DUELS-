using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongGiver : MonoBehaviour
{
    [SerializeField] AudioClip m_AudioClip;

    public void GiveIntroAudioClip()
    {
        SongSelector.Instance.GiveIntroSong(m_AudioClip);
    }
}