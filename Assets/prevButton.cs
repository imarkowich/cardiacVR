using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prevButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Text Body;
    FlashcardControl flash;
    flipTabButton flip;
    hideReport hide;
    public GameObject test;
    public GameObject flipper;
    public GameObject neb;
    public nextTabButton nexty;


    public void setText()
    {
        flash = test.GetComponent<FlashcardControl>();
        flip = flipper.GetComponent<flipTabButton>();
        hide = flipper.GetComponent<hideReport>();
        nexty = neb.GetComponent<nextTabButton>();

        nexty.flashCardCounter = nexty.flashCardCounter - 2;
        if(nexty.flashCardCounter < 0)
        {
            nexty.flashCardCounter = 0;
        }
        
        if(nexty == null)
        {
            Debug.Log("VERY BIG PROBLEM");
        }
        //Debug.Log("THIS IS QUESTIONS LENGTH: " + seeesvee.flashCardquestions.Length);
        Debug.Log("THIS IS FLASHCARDCOUNTER: " + nexty.flashCardCounter);
        Body.text = "Q: " + flash.flashy.Flashcards[nexty.flashCardCounter].Prompt;
        //seeesvee.flashCardquestions[seeesvee.flashCardCounter];
        if (flip.flag == true)
        {
            flip.flag = false;
        }
        if(hide.flag == true)
        {
            hide.flag = false;
        }
        nexty.flashCardCounter++;
        int len = flash.flashy.Flashcards.Count;
        if (nexty.flashCardCounter > len - 1)
        {
            nexty.flashCardCounter = 0;
        }
        Debug.Log("THIS IS FLASHCARDCOUNTER AT THE END OF PRESSING: " + nexty.flashCardCounter);
    }
}
