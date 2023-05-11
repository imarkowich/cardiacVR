using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Vector3 = UnityEngine.Vector3;

public class GrabberScale : MonoBehaviour
{
    float sliderVal;
    public GameObject heart_main_obj;
    Vector3 objectScale;
    Vector3 heartS;
    XRGrabInteractable interact;
    float resetVal = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        //sliderVal = GetComponent<Slider>().value;
        // Gets the local scale of game object
        heartS = heart_main_obj.transform.lossyScale;
        interact = heart_main_obj.GetComponent<XRGrabInteractable>();
    }

    public void Graba()
    {
        Debug.Log("WOWZA!");
        //interact.enabled = false;
        // transform scale
        heart_main_obj.transform.localScale
            = new Vector3(heartS.x * resetVal, heartS.y * resetVal, heartS.z * resetVal);
       // interact.enabled = true;
    }

    public void Reset()
    {
        GetComponent<Slider>().value = 1;
        heart_main_obj.transform.localScale = heartS;
    }
}
