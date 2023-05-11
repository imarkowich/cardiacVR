using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class nextTabButton : MonoBehaviour
{

    public Text Body;
    FlashcardControl flash;
    flipTabButton flip;
    hideReport hide;
    public GameObject test;
    public GameObject flipper;
    public int flashCardCounter;
    public int len;
    
    public void start()
    {

        flashCardCounter = 0;
       
    }
    public void setText()
    {
        flash = test.GetComponent<FlashcardControl>();
        flip = flipper.GetComponent<flipTabButton>();
        hide = flipper.GetComponent<hideReport>();
        len = flash.flashy.Flashcards.Count;
        if(flash == null)
        {
            Debug.Log("VERY BIG PROBLEM");
        }
        if(flashCardCounter == len)
        {
           flashCardCounter = len - 1;
        }
        //Debug.Log("THIS IS QUESTIONS LENGTH: " + seeesvee.flashCardquestions.Length);
        Debug.Log("THIS IS FLASHCARDCOUNTER: " + flashCardCounter);
        Body.text = "Q: " + flash.flashy.Flashcards[flashCardCounter].Prompt;
        if(flip.flag == true)
        {
            flip.flag = false;
        }
        if(hide.flag == true)
        {
            hide.flag = false;
        }
        flashCardCounter++;
        Debug.Log("THIS IS flashcards length: " + len);
        Debug.Log("THIS IS FLASHCARDCOUNTER before if statement" + flashCardCounter);
         
        
        Debug.Log("THIS IS FLASHCARDCOUNTER AT THE END OF PRESSING: " + flashCardCounter);
    }

}
