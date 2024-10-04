using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText; // [SerializeField => show private variable in inspector
    [SerializeField] float remainingTime;
    public bool countdownFinish = false;
    // Update is called once per frame
    void Update()
    {
        if(countdownFinish == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0f;
                countdownFinish = true;
            }
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownText.text = string.Format("{0}", seconds);
        }
    }
}
