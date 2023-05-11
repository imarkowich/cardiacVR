using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleTurn : MonoBehaviour
{
    public bool status = false;
    public ActionBasedContinuousTurnProvider smooth;
    public ActionBasedSnapTurnProvider snap;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnToggleClicked(bool isOn)
    {   
        // turning on
        if (status == false)
        {
            Debug.Log("toggle is ON");
            status = true;
            smooth.enabled = true;
            snap.enabled = false;
        }
        // turning off
        else
        {
            Debug.Log("toggle is OFF");
            status = false;
            smooth.enabled = false;
            snap.enabled = true;
        }
    }
}
