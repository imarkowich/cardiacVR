using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NextButton : MonoBehaviour
{
    public TMP_Text Body;
    public readCSV seeesvee;

    public void setText()
    {
        Body.text = seeesvee.flashCardquestions[seeesvee.flashCardCounter];
    }
}