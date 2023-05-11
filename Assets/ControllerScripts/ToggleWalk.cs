using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleWalk : MonoBehaviour
{
    public bool status = false;

    public TeleportationProvider teleport;
    public ActionBasedContinuousMoveProvider walk;

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
            walk.enabled = true;
            teleport.enabled = false;
        }
        // turning off
        else
        {
            Debug.Log("toggle is OFF");
            status = false;
            walk.enabled = false;
            teleport.enabled = true;
        }
    }
}
