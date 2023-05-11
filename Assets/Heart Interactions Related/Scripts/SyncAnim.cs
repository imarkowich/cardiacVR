using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;

public class SyncAnim : MonoBehaviour
{
    // ecg, heart, anatomy
    public GameObject ecg_obj;
    public GameObject heart_obj;
    public GameObject heart_main_obj;
    VideoPlayer ecg;
    MeshRenderer ecgMaterial;
    Animator heartAnimator;
    Animator anatomy;
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
    // 4 heart button objects
    public GameObject Sinus_Btn_obj;
    public GameObject AVNRT_Btn_obj;
    public GameObject AFlut_Btn_obj;
    public GameObject AFib_Btn_obj;
    // blood & elec button objects
    public GameObject Blood_Btn_obj;
    public GameObject Elec_Btn_obj;
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
    // 4 heart butttons
    Image Sinus_Btn;
    Image AVNRT_Btn;
    Image AFlut_Btn;
    Image AFib_Btn;
    // blood & elec buttons
    Image Blood_Btn;
    Image Elec_Btn;
    // symptom text
    public GameObject symptom_txt_obj;
    CycleSymptoms symptom_window;
    // heart rate slider
    public GameObject speed_slider_obj;
    SpeedMax speed_slider;  
    // flow booleans
    public bool elecActive = false;
    public bool bloodActive = false;
    public bool triggerElec = false;
    public bool triggerBlood = false;
    // extra
    public List<VideoClip> videoClips = new List<VideoClip>();
    public Material videoMaterial;
    Mode currentMode = Mode.idle;
    float cancelWaitTime = 1.1f;
    float startupTime = 10.0f;
    public bool busySwitching = false;
    // rgba colors
    public Color selectedColor = new Color(0.5f,0.5f,1.0f,1.0f);
    public Color deselectedColor = Color.white;


    enum Mode
    {
        Sinus,
        AVNRT,
        AFlut,
        AFib,
        idle
    }

    // Start is called before the first frame update
    void Start()
    {

        // ecg & heart       
        ecgMaterial = ecg_obj.GetComponent<MeshRenderer>();
        ecg = ecg_obj.GetComponent<VideoPlayer>();
        heartAnimator = heart_obj.GetComponent<Animator>();
        anatomy = heart_main_obj.GetComponent<Animator>();
        // sinus elec anims
        SA = SA_obj.GetComponent<Animator>();
        AV = AV_obj.GetComponent<Animator>();
        E1 = E1_obj.GetComponent<Animator>();
        E2 = E2_obj.GetComponent<Animator>();
        E3 = E3_obj.GetComponent<Animator>();
        E4 = E4_obj.GetComponent<Animator>();
        E5 = E5_obj.GetComponent<Animator>();
        E6 = E6_obj.GetComponent<Animator>();
        // sinus blood anims
        B1 = B1_obj.GetComponent<Animator>();
        B2 = B2_obj.GetComponent<Animator>();
        B3 = B3_obj.GetComponent<Animator>();
        B4 = B4_obj.GetComponent<Animator>();
        B5 = B5_obj.GetComponent<Animator>();
        B6 = B6_obj.GetComponent<Animator>();
        B7 = B7_obj.GetComponent<Animator>();
        // 4 heart buttons
        Sinus_Btn = Sinus_Btn_obj.GetComponent<Image>();
        AVNRT_Btn = AVNRT_Btn_obj.GetComponent<Image>();
        AFlut_Btn = AFlut_Btn_obj.GetComponent<Image>();
        AFib_Btn = AFib_Btn_obj.GetComponent<Image>();
        // blood & elec buttons
        Blood_Btn = Blood_Btn_obj.GetComponent<Image>();
        Elec_Btn = Elec_Btn_obj.GetComponent<Image>();
        // heart rate slider, symptoms window
        speed_slider = speed_slider_obj.GetComponent<SpeedMax>();
        symptom_window = symptom_txt_obj.GetComponent<CycleSymptoms>();

        // play Sinus
        StartCoroutine(BeginSinus());
    }

    public IEnumerator BeginSinus()
    {
        WaitForSeconds waitTime = new WaitForSeconds(startupTime);
        while (true)
        {
            yield return waitTime;
            break;
        }
        Debug.Log("Wowza!");
        Sinus_Btn_obj.GetComponent<Button>().onClick.Invoke();
    }

    public void SwitchMode(string newMode)
    {
        // exit if same state or if currently switching
        if (currentMode.ToString().Equals(newMode) || busySwitching)
        {
            return;
        }
        Debug.Log("WOWZA!");
        // 4 Modes, 0 rules
        switch (newMode)
        {
            case "Sinus":
                Debug.Log("SWITCH: Sinus");
                currentMode = Mode.Sinus;
                Sinus_Btn.color = selectedColor;
                AVNRT_Btn.color = deselectedColor;
                AFlut_Btn.color = deselectedColor;
                AFib_Btn.color = deselectedColor;
                break;
            case "AVNRT":
                Debug.Log("SWITCH: AVNRT");
                currentMode = Mode.AVNRT;
                Sinus_Btn.color = deselectedColor;
                AVNRT_Btn.color = selectedColor;
                AFlut_Btn.color = deselectedColor;
                AFib_Btn.color = deselectedColor;
                break;
            case "AFlut":
                Debug.Log("SWITCH: AFlut");
                currentMode = Mode.AFlut;
                Sinus_Btn.color = deselectedColor;
                AVNRT_Btn.color = deselectedColor;
                AFlut_Btn.color = selectedColor;
                AFib_Btn.color = deselectedColor;
                break;
            case "AFib":
                Debug.Log("SWITCH: AFib");
                currentMode = Mode.AFib;
                Sinus_Btn.color = deselectedColor;
                AVNRT_Btn.color = deselectedColor;
                AFlut_Btn.color = deselectedColor;
                AFib_Btn.color = selectedColor;
                break;
            default:
                break;
        }
        Play();
    }


    public void Play()
    {
        StartCoroutine(PlayVideo());
    }

    //Play ECG Video and Heart Animation.
    public IEnumerator PlayVideo()
    {
        // cancel current animation(S)
        heartAnimator.SetTrigger("CancelTrigger");
        // cancel elec anims
        SA.SetTrigger("CancelTrigger");
        AV.SetTrigger("CancelTrigger");
        E1.SetTrigger("CancelTrigger");
        E2.SetTrigger("CancelTrigger");
        E3.SetTrigger("CancelTrigger");
        E4.SetTrigger("CancelTrigger");
        E5.SetTrigger("CancelTrigger");
        E6.SetTrigger("CancelTrigger");
        elecActive = false;
        triggerElec = false;
        Elec_Btn.color = deselectedColor;
        Elec_Btn.color = deselectedColor;
        // cancel blood anims
        B1.SetTrigger("CancelTrigger");
        B2.SetTrigger("CancelTrigger");
        B3.SetTrigger("CancelTrigger");
        B4.SetTrigger("CancelTrigger");
        B5.SetTrigger("CancelTrigger");
        B6.SetTrigger("CancelTrigger");
        B7.SetTrigger("CancelTrigger");
        bloodActive = false;
        triggerBlood = false;
        Blood_Btn.color = deselectedColor;
        Blood_Btn.color = deselectedColor;

        // play switching anim, lock buttons & heartrate slider while switching modes
        anatomy.SetTrigger("SwitchTrigger");
        speed_slider.LockSlider();
        busySwitching = true;

        // Select the correct video in the array.
        switch (currentMode)
        {
            case Mode.Sinus:
                ecg.clip = videoClips[0];
                break;
            case Mode.AVNRT:
                ecg.clip = videoClips[1];
                break;
            case Mode.AFlut:
                ecg.clip = videoClips[2];
                break;
            case Mode.AFib:
                ecg.clip = videoClips[3];
                break;
            default:
                break;
        }
        
        // To ensure that the ECG video and Rhythm animation are in sync,
        // wait for the video to buffer before playing animations.
        ecg.Prepare();

        // Loop until video is prepared.
        WaitForSeconds waitTime = new WaitForSeconds(cancelWaitTime);
        while (!ecg.isPrepared)
        {
            Debug.Log("Preparing Video");
            // Loading.SetActive(true);
            yield return waitTime;
            break;
        }

        // Debug.Log("Done Preparing Video");
        // Loading.SetActive(true);

        // now we play video, heart animation, elec animation, & blood animations
        // Play video
        ecg.Play();
        ecgMaterial.material = videoMaterial;

        // Play Animations: heart, blood, elec
        switch (currentMode)
        {
            case Mode.Sinus:
                heartAnimator.SetTrigger("SinusTrigger");
                symptom_window.SinusSymptom();
                break;
            case Mode.AVNRT:
                heartAnimator.SetTrigger("AVNRTTrigger");
                symptom_window.AVNRTSymptom();
                break;
            case Mode.AFlut:
                heartAnimator.SetTrigger("AFlutTrigger");
                symptom_window.AFlutSymptom();
                break;
            case Mode.AFib:
                heartAnimator.SetTrigger("AFibTrigger");
                symptom_window.AFibSymptom();
                break;
            default:
                break;
        }

        // End switching, unlock everything
        speed_slider.UnlockSlider();
        busySwitching = false;

    }

    // toggle blood flow bool
    public void ToggleBloodFlow()
    {
        if (bloodActive == true)
        {
            bloodActive = false;
            triggerBlood = false;
            B1.SetTrigger("CancelTrigger");
            B2.SetTrigger("CancelTrigger");
            B3.SetTrigger("CancelTrigger");
            B4.SetTrigger("CancelTrigger");
            B5.SetTrigger("CancelTrigger");
            B6.SetTrigger("CancelTrigger");
            B7.SetTrigger("CancelTrigger");
            Blood_Btn.color = deselectedColor;
            Debug.Log("BLOOD OFF: Blaap!");
        }
        else
        {
            bloodActive = true;
            triggerBlood = true;
            Blood_Btn.color = selectedColor;
            Debug.Log("BLOOD ON: Bloop!");
        }
    }

    // toggle elec flow bool
    public void ToggleElecFlow()
    {
        if (elecActive == true)
        {
            elecActive = false;
            triggerElec = false;
            SA.SetTrigger("CancelTrigger");
            AV.SetTrigger("CancelTrigger");
            E1.SetTrigger("CancelTrigger");
            E2.SetTrigger("CancelTrigger");
            E3.SetTrigger("CancelTrigger");
            E4.SetTrigger("CancelTrigger");
            E5.SetTrigger("CancelTrigger");
            E6.SetTrigger("CancelTrigger");
            Elec_Btn.color = deselectedColor;
            Debug.Log("ELEC OFF: Bzzzoouuw!");
        } else
        {
            elecActive = true;
            triggerElec = true;
            Elec_Btn.color = selectedColor;
            Debug.Log("ELEC ON: Bzzzuuoop!");
        }
    }
}
