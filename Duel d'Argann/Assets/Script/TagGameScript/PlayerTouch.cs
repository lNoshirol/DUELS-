using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{

    [SerializeField] private string _tag;
    [SerializeField] private GameObject _bomb;


    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            Debug.Log("Touché !");
            if (_bomb.activeInHierarchy) _bomb.SetActive(false); else _bomb.SetActive(true);//suce
        }
    }
}
