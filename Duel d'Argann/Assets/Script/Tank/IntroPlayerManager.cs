using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayerManager : MonoBehaviour
{
    [SerializeField] GameObject _joueur1;
    [SerializeField] GameObject _joueur2;

    private void OnEnable()
    {
        StartCoroutine(ThePlayerIntro());
    }

    IEnumerator ThePlayerIntro()
    {
        _joueur1.SetActive(true);
        _joueur1.GetComponent<PLayerSounds>().PlayIntroSound();
        yield return new WaitForSeconds(_joueur1.GetComponent<PLayerSounds>().introSound.length);
        
        _joueur2.SetActive(true);
        _joueur2.GetComponent<PLayerSounds>().PlayIntroSound();
    }
}