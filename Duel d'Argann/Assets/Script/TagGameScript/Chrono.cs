using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    [SerializeField] float _timer;
    [SerializeField] TMP_Text _textTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChronoTime());
    }
    private void Update()
    {
        _textTimer.text = _timer.ToString();
        Debug.Log(_timer);
    }
    public IEnumerator ChronoTime()
    {
        _timer--;
        yield return new WaitForSeconds(1);  
        if (_timer > 0)
        {
            StartCoroutine(ChronoTime());
        }        
    }
}
