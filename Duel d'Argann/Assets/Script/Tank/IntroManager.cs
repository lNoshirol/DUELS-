using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    private VideoPlayer _vidPlayer;
    [SerializeField] GameObject _theScene;

    // Start is called before the first frame update
    void Start()
    {
        _vidPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(WaitBeforeAllAppear());
    }

    IEnumerator WaitBeforeAllAppear()
    {
        yield return new WaitForSeconds((float)_vidPlayer.clip.length);
        _theScene.SetActive(true);
        gameObject.SetActive(false);
    }
}