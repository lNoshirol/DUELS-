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

    [SerializeField] GameObject jspFrere;
    [SerializeField] GameObject jspFrere2;
    [SerializeField] GameObject jspFrere3;
    [SerializeField] GameObject jspFrere4;
    [SerializeField] GameObject jspFrere5;

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
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Lucas Scene");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator StartSongAndDestroy()
    {
        jspFrere.SetActive(false);
        jspFrere2.SetActive(false);
        jspFrere3.SetActive(false);
        jspFrere4.SetActive(false);
        jspFrere5.SetActive(false);
        m_AudioSource.PlayOneShot(outroSong);
        ReloadShit.SetActive(true);
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene("Lucas Scene");
    }
}