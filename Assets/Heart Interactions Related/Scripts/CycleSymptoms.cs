using System.Collections;
using System.Collections.Generic;
using TMPro;
// using TMPro.EditorUtilities;
using UnityEngine;

public class CycleSymptoms : MonoBehaviour
{
    public string Sinus = "• Healthy Function";
    public string AVNRT = "• Palpitations\n• Dizziness\n• Shortness of Breath\n• Syncope\n";
    public string AFlut = "• Palpitations\n• Fatigue\n• Shortness of Breath\n• Lightheadedness\n";
    public string AFib  = "• Palpitations\n• Tachycardia\n• Fatigue\n• Dizziness\n";

    TextMeshProUGUI symptomText;

    // Start is called before the first frame update
    
    void Start()
    {
        symptomText = GetComponent<TextMeshProUGUI>();
    }

    public void SinusSymptom()
    {
        symptomText.text = Sinus;
    }

    public void AVNRTSymptom()
    {
        symptomText.text = AVNRT;
    }

    public void AFlutSymptom()
    {
        symptomText.text = AFlut;
    }

    public void AFibSymptom()
    {
        symptomText.text = AFib;
    }


}
