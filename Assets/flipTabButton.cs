using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flipTabButton : MonoBehaviour
{
    public bool flag = false;
    public Text Body;
    FlashcardControl flash;
    float confidenceSlider;
    public GameObject test;
    public GameObject neb;
    public nextTabButton nexty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    

    public void setText()
    {
        flash = test.GetComponent<FlashcardControl>();
        nexty = neb.GetComponent<nextTabButton>();
        if(flash == null)
        {
            Debug.Log("VERY BIG PROBLEM");
        }
        
        if(flag == false)
        {
            Body.text = "A: " + flash.flashy.Flashcards[nexty.flashCardCounter - 1].Answer;
            //seeesvee.flashCardanswers[seeesvee.flashCardCounter-1];
            Debug.Log("TESTSUCCES");
            confidenceSlider = GameObject.Find("SliderConfidence").GetComponent<Slider>().value;
            Debug.Log("THIS IS CONFIDENCE" + confidenceSlider);
        }
        if(flag == true)
        {
            Body.text = "Q: " + flash.flashy.Flashcards[nexty.flashCardCounter - 1].Prompt;
            //seeesvee.flashCardquestions[seeesvee.flashCardCounter-1];
            Debug.Log("FLAGSUCCES");
        }
        //Body.text = seeesvee.flashCardanswers[seeesvee.flashCardCounter];
        //Debug.Log("TESTSUCCES");

        flag = !flag;
        //seeesvee.flashCardCounter++;
        
    }

}
