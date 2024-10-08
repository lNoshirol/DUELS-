using System.Collections;
using TMPro;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    [field : SerializeField] public float Timer {  get; set; }
    [SerializeField] TMP_Text _textTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChronoTime());
    }
    private void Update()
    {
        _textTimer.text = Timer.ToString();
        Debug.Log(Timer);
    }
    public IEnumerator ChronoTime()
    {
        Timer--;
        yield return new WaitForSeconds(1);  
        if (Timer > 0)
        {
            StartCoroutine(ChronoTime());
        }        
    }
}
