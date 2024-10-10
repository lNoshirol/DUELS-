using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static Win Instance;

    [SerializeField] GameObject PLayerWinner;
    [SerializeField] GameObject WinPanel;
    [SerializeField] TextMeshProUGUI WinTextPlayer;

    private void Awake()
    {
        Instance = this;
    }

    public void AndThisIsTheWin(GameObject player)
    {
        

        WinPanel.SetActive(true);
        player.GetComponent<PLayerSounds>().PlayWinSound();
        WinTextPlayer.text = player.name + " ! gg mec, t'as gagné. Alors heureux ?";
    }
}