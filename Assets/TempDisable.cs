using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TempDisable : MonoBehaviour
{
    public InputActionReference gripPressed;
    public ActionBasedContinuousTurnProvider smooth;
    public TeleportationProvider teleport;
    public ActionBasedSnapTurnProvider snap;
    public ActionBasedContinuousMoveProvider walk;

    bool[] isOn = new bool[4];

    private void OnEnable()
    {
        gripPressed.action.Enable(); // Enable the grip button action when the script is enabled
        gripPressed.action.performed += OnGripPressed; // Add a callback for when the grip button is pressed
        gripPressed.action.canceled += OnGripReleased; // Add a callback for when the grip button is released
    }

    private void OnDisable()
    {
        gripPressed.action.Disable(); // Disable the grip button action when the script is disabled
        gripPressed.action.performed -= OnGripPressed; // Remove the callback for when the grip button is pressed
        gripPressed.action.canceled -= OnGripReleased; // Remove the callback for when the grip button is released
    }

    public void OnGripPressed(InputAction.CallbackContext context)
    {   
        // Remember which ones were turned on before
        isOn[0] = smooth.enabled;
        isOn[1] = snap.enabled;
        isOn[2] = walk.enabled;
        isOn[3] = teleport.enabled;
        

        // Disable everything
        smooth.enabled = false;
        teleport.enabled = false;
        snap.enabled = false;
        walk.enabled = false;
        Debug.Log("Grip button pressed event fired");
    }

    public void OnGripReleased(InputAction.CallbackContext context)
    {   
        // Reenable what was already on
        // Reenable turning
        if (isOn[0])
        {
            smooth.enabled = true;
        }
        else
        {
            snap.enabled = true;
        }

        // Reenable moving
        if (isOn[2])
        {
            walk.enabled = true;
        }
        else
        {
            teleport.enabled = true;
        }


        Debug.Log("Grip button released");
    }
}
