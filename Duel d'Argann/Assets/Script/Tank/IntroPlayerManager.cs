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
        _joueur1.GetComponent<Control>().enabled = false;
        _joueur2.GetComponent<Control>().enabled = false;

        _joueur1.GetComponent<Fire>().enabled = false;
        _joueur2.GetComponent<Fire>().enabled = false;

        _joueur1.SetActive(true);
        _joueur1.GetComponent<PLayerSounds>().PlayIntroSound();
        yield return new WaitForSeconds(_joueur1.GetComponent<PLayerSounds>().introSound.length);
        
        _joueur2.SetActive(true);
        _joueur2.GetComponent<PLayerSounds>().PlayIntroSound();

        yield return new WaitForSeconds(_joueur2.GetComponent <PLayerSounds>().introSound.length);

        _joueur1.GetComponent<Control>().enabled = true;
        _joueur2.GetComponent<Control>().enabled = true;

        _joueur1.GetComponent<Fire>().enabled = true;
        _joueur2.GetComponent<Fire>().enabled = true;  
    }
}