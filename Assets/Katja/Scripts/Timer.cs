using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public int currentTime = 60;
    public TextMeshProUGUI timerToText;

    public static event Action OnTimerEnded;

    public void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        while (true)
        {
            DecreaseTime();
            yield return new WaitForSeconds(1);
        }
    }

    void DecreaseTime()
    {
        if (currentTime > 0)
        {
            currentTime -= 1;
            timerToText.text = currentTime.ToString();
        }
        

        if (currentTime == 0)
        {
            OnTimerEnded?.Invoke();
        }
    }
}
