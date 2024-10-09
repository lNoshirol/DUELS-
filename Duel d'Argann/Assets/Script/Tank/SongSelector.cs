using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SongSelector : MonoBehaviour
{
    public static SongSelector Instance;

    [SerializeField] PLayerSounds selectedPlayer;
    [SerializeField] TextMeshProUGUI playerText;

    private void Awake()
    {
        Instance = this;
    }

    public void GivePlayer(PLayerSounds TheNewPlayer)
    {
        selectedPlayer = TheNewPlayer;
        playerText.text = selectedPlayer.gameObject.name;
    }

    public void GiveIntroSong(AudioClip newAudioClip)
    {
        selectedPlayer.introSound = newAudioClip;
    }

    public void GiveFireSong(AudioClip newAudioClip)
    {
        selectedPlayer.fireSound = newAudioClip;
    }

    public void GiveHitSong(AudioClip newAudioClip)
    {
        selectedPlayer.hitSound = newAudioClip;
    }

    public void GiveDeadSong(AudioClip newAudioClip)
    {
        selectedPlayer.deadSound = newAudioClip;
    }

    public void GiveWinSong(AudioClip newAudioClip)
    {
        selectedPlayer.winSound = newAudioClip;
    }
}