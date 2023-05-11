using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CaseTimer : MonoBehaviour
{
    float currentTime;
    bool timerActive;

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
            currentTime += Time.deltaTime;
    }

    public void StartTimer()
    {
        currentTime = 0;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public string GetTimeElapsed()
    {
        StopTimer();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        Debug.Log("Time spent: " + time.ToString(@"hh\:mm\:ss"));

        return time.ToString(@"hh\:mm\:ss");
    }
}
