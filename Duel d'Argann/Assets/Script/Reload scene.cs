using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloadscene : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] AudioClip outroSong;

    [SerializeField] bool HasPressedYKey;

    [SerializeField] GameObject ReloadShit;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
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
        m_AudioSource.PlayOneShot(outroSong);
        ReloadShit.SetActive(true);
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene("Lucas Scene");
    }
}