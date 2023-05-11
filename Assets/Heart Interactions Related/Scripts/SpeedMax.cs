using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SpeedMax : MonoBehaviour
{
    // slider    
    public GameObject holder_obj;
    public GameObject slider_obj;
    Slider speedSlider;
    float sliderVal;
    // ecg & video
    public GameObject ecg_obj;
    public GameObject heart_obj;
    VideoPlayer ecg;
    Animator heartAnimator;
    // electric flow objects
    public GameObject SA_obj;
    public GameObject AV_obj;
    public GameObject E1_obj;
    public GameObject E2_obj;
    public GameObject E3_obj;
    public GameObject E4_obj;
    public GameObject E5_obj;
    public GameObject E6_obj;
    // blood flow objects
    public GameObject B1_obj;
    public GameObject B2_obj;
    public GameObject B3_obj;
    public GameObject B4_obj;
    public GameObject B5_obj;
    public GameObject B6_obj;
    public GameObject B7_obj;
    // electric flow anims
    Animator SA;
    Animator AV;
    Animator E1;
    Animator E2;
    Animator E3;
    Animator E4;
    Animator E5;
    Animator E6;
    // blood flow anims
    Animator B1;
    Animator B2;
    Animator B3;
    Animator B4;
    Animator B5;
    Animator B6;
    Animator B7;

    // Start is called before the first frame update
    void Start()
    {
        // get slider value, ecg, heart
        speedSlider = slider_obj.GetComponent<UnityEngine.UI.Slider>();
        sliderVal = slider_obj.GetComponent<Slider>().value;
        // ecg & heart
        ecg = ecg_obj.GetComponent<VideoPlayer>();
        heartAnimator = heart_obj.GetComponent<Animator>();
        // sinus elec anims
        SA = SA_obj.GetComponent<Animator>();
        AV = AV_obj.GetComponent<Animator>();
        E1 = E1_obj.GetComponent<Animator>();
        E2 = E2_obj.GetComponent<Animator>();
        E3 = E3_obj.GetComponent<Animator>();
        E4 = E4_obj.GetComponent<Animator>();
        E5 = E5_obj.GetComponent<Animator>();
        E6 = E6_obj.GetComponent<Animator>();
        //sinus blood anims
        B1 = B1_obj.GetComponent<Animator>();
        B2 = B2_obj.GetComponent<Animator>();
        B3 = B3_obj.GetComponent<Animator>();
        B4 = B4_obj.GetComponent<Animator>();
        B5 = B5_obj.GetComponent<Animator>();
        B6 = B6_obj.GetComponent<Animator>();
        B7 = B7_obj.GetComponent<Animator>();
    }

    // do sppedd - update the spedd when slider is moved
    public void DoSpeed()
    {
        // Debug.Log("DoSpeed");
        // update speed
        sliderVal = slider_obj.GetComponent<Slider>().value;
        // Debug.Log("sliderVal: " + sliderVal);
        // ecg, heart speed
        ecg.playbackSpeed = sliderVal;
        heartAnimator.speed = sliderVal;
        // elec speed
        SA.speed = sliderVal;
        AV.speed = sliderVal;
        E1.speed = sliderVal;
        E2.speed = sliderVal;
        E3.speed = sliderVal;
        E4.speed = sliderVal;
        E5.speed = sliderVal;
        E6.speed = sliderVal;
        // blood speed
        B1.speed = sliderVal;
        B2.speed = sliderVal;
        B3.speed = sliderVal;
        B4.speed = sliderVal;
        B5.speed = sliderVal;
        B6.speed = sliderVal;
        B7.speed = sliderVal;
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