using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SpeedMax2nd : MonoBehaviour
{
    // slider    
    public GameObject slider_obj;
    Slider speedSlider;
    float sliderVal;
    public GameObject heart_obj;
    VideoPlayer ecg;
    Animator heartAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // get slider value, ecg, heart
        speedSlider = slider_obj.GetComponent<UnityEngine.UI.Slider>();
        sliderVal = slider_obj.GetComponent<Slider>().value;
        heartAnimator = heart_obj.GetComponent<Animator>();
    }

    // do sppedd - update the spedd when slider is moved
    public void DoSpeed()
    {
        // Debug.Log("DoSpeed");
        // update speed
        sliderVal = slider_obj.GetComponent<Slider>().value;
        // Debug.Log("sliderVal: " + sliderVal);
        heartAnimator.speed = sliderVal;
    }

    
    // lock off speed slider & reset the heart rate to 1.0 (default)
    public void LockSlider()
    {
        Debug.Log("= = = = = = = = = = = = = = = = = = = = LOCK rate Slider");
        speedSlider.value = 1.0f;
        speedSlider.enabled = false;
    }

    // UN-lock slider & reset the heart rate to 1.0 (default)
    public void UnlockSlider()
    {
        Debug.Log("- - - - - - - - - - - - - - - - - - - - UNLOCK rate slider");
        speedSlider.enabled = true;
        speedSlider.value = 1.0f;
    }
    
}