using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UnActivaterTroisMilleDeluxePreniumGoldEdition : MonoBehaviour
{
    [SerializeField] float timer;

    private void OnEnable()
    {
        StartCoroutine(ATTENNNND());
    }

    IEnumerator ATTENNNND()
    {
        yield return new WaitForSeconds(timer);
    }
}