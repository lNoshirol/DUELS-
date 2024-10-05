using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SetActiveFalseAfter());
    }

    IEnumerator SetActiveFalseAfter()
    {
        yield return new WaitForSeconds(3.5f);
        gameObject.SetActive(false);
    }
}