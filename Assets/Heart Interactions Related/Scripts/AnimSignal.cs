using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSignal : MonoBehaviour
{
    // heart mode selector
    public GameObject modeMenu;
    bool triggerElec = false;
    bool triggerBlood = false;
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
        triggerElec = modeMenu.GetComponent<SyncAnim>().triggerElec;
        triggerBlood = modeMenu.GetComponent<SyncAnim>().triggerBlood;
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

    // start loop Sinus
    public void SignalLoopSinus()
    {
        // retrieve trigger bools from SyncAnim script
        triggerElec = modeMenu.GetComponent<SyncAnim>().triggerElec;
        triggerBlood = modeMenu.GetComponent<SyncAnim>().triggerBlood;
        //Debug.Log("sinus beep - E: " + triggerElec + ", B: " + triggerBlood);

        // trigger elec animation if toggled on
        if (triggerElec == true)
        {
            Debug.Log("SINUS ELECTRIC GO!!!");
            triggerElec = false;
            modeMenu.GetComponent<SyncAnim>().triggerElec = false;
            SA.SetTrigger("SinusTrigger");
            AV.SetTrigger("SinusTrigger");
            E1.SetTrigger("SinusTrigger");
            E2.SetTrigger("SinusTrigger");
            E3.SetTrigger("SinusTrigger");
            E4.SetTrigger("SinusTrigger");
            E5.SetTrigger("SinusTrigger");
            E6.SetTrigger("SinusTrigger");
        }

        // trigger blood animation if toggled on
        if (triggerBlood == true)
        {
            Debug.Log("SINUS BLOOD GO!!!");
            triggerBlood = false;
            modeMenu.GetComponent<SyncAnim>().triggerBlood = false;
            B1.SetTrigger("SinusTrigger");
            B2.SetTrigger("SinusTrigger");
            B3.SetTrigger("SinusTrigger");
            B4.SetTrigger("SinusTrigger");
            B5.SetTrigger("SinusTrigger");
            B6.SetTrigger("SinusTrigger");
            B7.SetTrigger("SinusTrigger");
        }
    }


    //start loop AVNRT
    public void SignalLoopAVNRT()
    {
        // retrieve trigger bools from SyncAnim script
        triggerElec = modeMenu.GetComponent<SyncAnim>().triggerElec;
        triggerBlood = modeMenu.GetComponent<SyncAnim>().triggerBlood;
        //Debug.Log("AVNRT beep - E: " + triggerElec + ", B: " + triggerBlood);

        // trigger elec animation if toggled on
        if (triggerElec == true)
        {
            Debug.Log("AVNRT ELECTRIC GO!!!");
            triggerElec = false;
            modeMenu.GetComponent<SyncAnim>().triggerElec = false;
            SA.SetTrigger("AVNRTTrigger");
            AV.SetTrigger("AVNRTTrigger");
            E1.SetTrigger("AVNRTTrigger");
            E2.SetTrigger("AVNRTTrigger");
            E3.SetTrigger("AVNRTTrigger");
            E4.SetTrigger("AVNRTTrigger");
            E5.SetTrigger("AVNRTTrigger");
            E6.SetTrigger("AVNRTTrigger");
        }

        // trigger blood animation if toggled on
        if (triggerBlood == true)
        {
            Debug.Log("AVNRT BLOOD GO!!!");
            triggerBlood = false;
            modeMenu.GetComponent<SyncAnim>().triggerBlood = false;
            B1.SetTrigger("AVNRTTrigger");
            B2.SetTrigger("AVNRTTrigger");
            B3.SetTrigger("AVNRTTrigger");
            B4.SetTrigger("AVNRTTrigger");
            B5.SetTrigger("AVNRTTrigger");
            B6.SetTrigger("AVNRTTrigger");
            B7.SetTrigger("AVNRTTrigger");
        }
    }

    
    // start loop AFLUT
    public void SignalLoopAFlut()
    {
        // retrieve trigger bools from SyncAnim script
        triggerElec = modeMenu.GetComponent<SyncAnim>().triggerElec;
        triggerBlood = modeMenu.GetComponent<SyncAnim>().triggerBlood;
        //Debug.Log("AFlut beep - E: " + triggerElec + ", B: " + triggerBlood);

        // trigger elec animation if toggled on
        if (triggerElec == true)
        {
            Debug.Log("AFlut ELECTRIC GO!!!");
            triggerElec = false;
            modeMenu.GetComponent<SyncAnim>().triggerElec = false;
            SA.SetTrigger("AFlutTrigger");
            AV.SetTrigger("AFlutTrigger");
            E1.SetTrigger("AFlutTrigger");
            E2.SetTrigger("AFlutTrigger");
            E3.SetTrigger("AFlutTrigger");
            E4.SetTrigger("AFlutTrigger");
            E5.SetTrigger("AFlutTrigger");
            E6.SetTrigger("AFlutTrigger");
        }

        // trigger blood animation if toggled on
        if (triggerBlood == true)
        {
            Debug.Log("AFlut BLOOD GO!!!");
            triggerBlood = false;
            modeMenu.GetComponent<SyncAnim>().triggerBlood = false;
            B1.SetTrigger("AFlutTrigger");
            B2.SetTrigger("AFlutTrigger");
            B3.SetTrigger("AFlutTrigger");
            B4.SetTrigger("AFlutTrigger");
            B5.SetTrigger("AFlutTrigger");
            B6.SetTrigger("AFlutTrigger");
            B7.SetTrigger("AFlutTrigger");
        }
    }


    // start loop AFIB
    public void SignalLoopAFib()
    {
        // retrieve trigger bools from SyncAnim script
        triggerElec = modeMenu.GetComponent<SyncAnim>().triggerElec;
        triggerBlood = modeMenu.GetComponent<SyncAnim>().triggerBlood;
        //Debug.Log("AFib beep - E: " + triggerElec + ", B: " + triggerBlood);

        // trigger elec animation if toggled on
        if (triggerElec == true)
        {
            Debug.Log("AFib ELECTRIC GO!!!");
            triggerElec = false;
            modeMenu.GetComponent<SyncAnim>().triggerElec = false;
            SA.SetTrigger("AFibTrigger");
            AV.SetTrigger("AFibTrigger");
            E1.SetTrigger("AFibTrigger");
            E2.SetTrigger("AFibTrigger");
            E3.SetTrigger("AFibTrigger");
            E4.SetTrigger("AFibTrigger");
            E5.SetTrigger("AFibTrigger");
            E6.SetTrigger("AFibTrigger");
        }

        // trigger blood animation if toggled on
        if (triggerBlood == true)
        {
            Debug.Log("AFib BLOOD GO!!!");
            triggerBlood = false;
            modeMenu.GetComponent<SyncAnim>().triggerBlood = false;
            B1.SetTrigger("AFibTrigger");
            B2.SetTrigger("AFibTrigger");
            B3.SetTrigger("AFibTrigger");
            B4.SetTrigger("AFibTrigger");
            B5.SetTrigger("AFibTrigger");
            B6.SetTrigger("AFibTrigger");
            B7.SetTrigger("AFibTrigger");
        }
    }
    

}
