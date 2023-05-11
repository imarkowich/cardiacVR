using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AfterloadClick : MonoBehaviour
{
    public TMP_Text Header, Body;

    public void setText()
    {
        Header.text = "Afterload";
        Body.text = "Afterload is the stress on the left ventricular wall during contraction. Importantly, " +
            "it is proportional to the aortic pressure the heart must eject blood against. As aortic pressure " +
            "increases, LV wall stress increases, but the volume of blood can be ejected against that load decreases.\n\n" +
            "Increaed aortic pressure = increased afterload, decreased stroke volume\n\n" +
            "Some factors that affect afterload:\nhypertension, aortic valve disease, aortic stenosis";
    }
}