using System;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float timeElapsed = 0;
    private TMP_Text txtTime;

    private void Start()
    {
        txtTime = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeElapsed);

        string timeInText;
        if (timeSpan.Hours != 0)
        {
            timeInText = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
        else if (timeSpan.Minutes != 0)
        {
            timeInText = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        }
        else
        {
            timeInText = string.Format("{0:00}", timeSpan.Seconds);
        }

        txtTime.SetText(timeInText);
    }
}