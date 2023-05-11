using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CycleAnatomy : MonoBehaviour
{
    public string DefaultPrompt = "With anatomy labels turned on, select one of the labels to learn more about it.";
    public string SA = "Sinoatrial node: specialized cardiac muscle fibers in the right atrium that initiate and regulate impulses for contraction of the heart. It is stimulated and inhibited by the sympathetic and parasympathetic division of the ANS, respectively. Supplied by SA nodal branches from either the right coronary artery (60% of people) or circumflex branch of the left coronary artery (40% of people).";
    public string AV = "Atrioventricular node: smaller collection of specialized cardiac muscle fibers in the interatrial septum that propagate impulses from the atria to the ventricles via the atrioventricular bundle, bundle branches, and subendocardial branches, also called Purkinje fibers. It is stimulated and inhibited by the sympathetic and parasympathetic division of the ANS, respectively. Supplied by AV nodal branch of the right coronary artery.";
    public string Aorta = "Aorta: receives oxygen-rich blood from the left ventricle and distributes it to the heart and body as part of systemic circulation.";
    public string LeftAtrium = "Left Atrium: receives oxygen-rich blood from the lungs via the pulmonary veins and delivers it to the left ventricle.";
    public string RightAtrium = "Right Atrium: receives oxygen-poor blood from the body via the superior and inferior vena cavae and from the heart via the coronary sinus and delivers it to the right ventricle.";
    public string LeftVentricle = "Left Ventricle: receives oxygen-rich blood from the left atrium and delivers it to the aorta.";
    public string RightVenticle = "Right Ventricle: receive oxygen-poor blood from the right atrium and distributes it to the lungs via the pulmonary trunk and pulmonary arteries for oxygenation as part of pulmonary circulation.";


    TextMeshProUGUI anatomyText;

    // Start is called before the first frame update

    void Start()
    {
        anatomyText = GetComponent<TextMeshProUGUI>();
        DeafultPrompt_Anatomy();
    }

    public void DeafultPrompt_Anatomy()
    {
        anatomyText.text = DefaultPrompt;
    }

    public void SA_Anatomy()
    {
        anatomyText.text = SA;
    }

    public void AV_Anatomy()
    {
        anatomyText.text = AV;
    }

    public void Aorta_Anatomy()
    {
        anatomyText.text = Aorta;
    }
    public void LeftAtriumAnatomy()
    {
        anatomyText.text = LeftAtrium;
    }

    public void RightAtrium_Anatomy()
    {
        anatomyText.text = RightAtrium;
    }

    public void LeftVentrical_Anatomy()
    {
        anatomyText.text = LeftVentricle;
    }

    public void RightVentrical_Anatomy()
    {
        anatomyText.text = RightVenticle;
    }

}   
