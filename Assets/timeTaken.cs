using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable] public class timeTaken : MonoBehaviour
{

    public FlashAttempt post;
    public FlashcardControl flash;
    public nextTabButton nexter;
    public GameObject conf;
    public float timer;
    bool flag;
    bool reset;
    public string timeElapsed;
    //public FlashAttempt flashAttempt;
    public Slider confidence;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        flag = true;
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            timer += Time.deltaTime;
            //Debug.Log(timer);
        
        
    }

    public void isOn()
    {
        if(flag == true)
        {
            flag = false;
            Debug.Log("THIS IS OUTPUT TIMER: " + timer);

            TimeSpan time = TimeSpan.FromSeconds(timer);
            Debug.Log("Time spent: " + time.ToString(@"hh\:mm\:ss"));
            timeElapsed = time.ToString(@"hh\:mm\:ss");
            FlashAttempt flashAttempt = GetComponent<FlashAttempt>();
            confidence = conf.GetComponent<Slider>();

            if (LoginInfo.login != null)
            {
                flashAttempt.OnSubmit(
                    flash.flashy.Flashcards[nexter.flashCardCounter].FID,
                    LoginInfo.login.SID,
                    "100",
                    timeElapsed,
                    confidence.value.ToString(),
                    LoginInfo.login.LoggedIn
                );
            }

            this.enabled = false;
            timer = 0;
        }
        
    }
    public void next()
    {
        if(flag == true)
        {


            timer = 0;
        }
        flag = true;
    }


}
