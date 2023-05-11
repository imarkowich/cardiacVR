using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereInteraction : MonoBehaviour
{

    public class TriggerButtonTest : MonoBehaviour
    {
        void Update()
        {
            if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue)
            {
                Debug.Log("Hello World!");
            }
        }
    }

}
