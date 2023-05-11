using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ContractilityClick : MonoBehaviour
{
    public TMP_Text Header, Body;

    public void setText()
    {
        Header.text = "Contractility";
        Body.text = "The amount of calcuim entering a cardiac muscle cell affects its contractility, i.e., " +
                    "the rate and amount of tension it produces. The greater the calcium influx, the faster and " +
                    "stronger the contraction, and the greater the volume of blood that is ejected.\n\n" +
                    "Increased calium influx = increased contractility and increased stroke volume.\n\n" +
                    "Some factors that affect contractility:\n\nautonomic activity, pharmacological agents, hypercalcemia";
    }
}
