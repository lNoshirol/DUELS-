using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributePlayer : MonoBehaviour
{
    [SerializeField] PLayerSounds playerSounds;

    public void AttributePlayerToSongSelector()
    {
        SongSelector.Instance.GivePlayer(playerSounds);
    }
}