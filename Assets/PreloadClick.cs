using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PreloadClick : MonoBehaviour
{
    public TMP_Text Header, Body;

    public void setText()
    {
        Header.text = "Preload";
        Body.text = "Preload is the degree of stretching of cardiac muscle cells as the ventricles fill" +
                    "with blood. The more cardiac muscle cells are stretched, the greater the force they" +
                    "can produce, and the greater the volume of bloodthat is ejected.\n\nIncreased filling = " +
                    "Increased preload, Increased force, increased stroke volume\n\nSome variables that affect " +
                    "preload:\nCentral venous pressure, blood volume, gravity";
    }
}