using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postFlashScript : MonoBehaviour
{
    public FlashAttempt post;
    public FlashcardControl flash;
    //public FlashAttempt flashAttemptSubmit;
    public Slider confidenceSubmit;
    public timeTaken source;
    public GameObject selfreport;
    public string timeSubmit;
    public nextTabButton nexter;
    public Toggle result;
    public GameObject toggleObject;
    public string grade;
    public bool correctness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void posty()
    {

        //flashAttempt = GetComponent<FlashAttempt>();
        confidenceSubmit = source.confidence;
        timeSubmit = source.timeElapsed;
        FlashAttempt flashAttemptSubmit = GetComponent<FlashAttempt>();
        result = toggleObject.GetComponent<Toggle>();

        correctness = result.isOn;
        if(correctness == true)
        {
            grade = "100";
        }
        else
        {
            grade = "0";
        }

        if (LoginInfo.login != null)
        {
                post.OnSubmit(
                    flash.flashy.Flashcards[nexter.flashCardCounter].FID,
                    LoginInfo.login.SID,
                    grade, 
                    timeSubmit, 
                    confidenceSubmit.value.ToString(),
                    LoginInfo.login.LoggedIn
                );
                Debug.Log("WE ATTEMPTED TO DO SOMETHING");
        }
    }
}
