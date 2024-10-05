using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class FakeLoading : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] GameObject introVideo;
    private Slider slider;
    [SerializeField] GameObject introShit;
    [SerializeField] float _fakeLoadingSpeed;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != 1)
        slider.value += Time.deltaTime/_fakeLoadingSpeed;
        float sliderValueInPercent = slider.value * 100;
        int realPercentValue = (int)sliderValueInPercent;
        loadingText.text = realPercentValue.ToString() + " " + "%";
        if (loadingText.text == "100 %")
        {
            loadingText.color = Color.green;
            StartCoroutine(WaitADemiSecoond());
        }
    }

    IEnumerator WaitADemiSecoond()
    {
        yield return new WaitForSeconds(0.5f);
        introVideo.SetActive(true);
        introShit.SetActive(false);
        Destroy(GetComponent<FakeLoading>());
    }
}