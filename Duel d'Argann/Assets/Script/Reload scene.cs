using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloadscene : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] AudioClip outroSong;

    [SerializeField] GameObject introVid;
    [SerializeField] GameObject theWholeScene;

    [SerializeField] bool HasPressedYKey;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        theWholeScene.SetActive(false);
        StartCoroutine(LaunchAllAfterGameStart());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y) && !HasPressedYKey)
        {
            StartCoroutine(StartSongAndDestroy());
            HasPressedYKey = true;
        }
    }

    IEnumerator StartSongAndDestroy()
    {
        //m_AudioSource.clip = outroSong;
        m_AudioSource.PlayOneShot(outroSong);
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene("Lucas Scene");
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(10);
        theWholeScene.SetActive(true);
    }

    IEnumerator LaunchAllAfterGameStart()
    {
        yield return new WaitForSeconds(1);
        Destroy(introVid, 10);
        StartCoroutine(ATTEND());
    }
}
