using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashCardNumbero : MonoBehaviour
{
    public nextTabButton test;
    public Text Body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void setText()
    {
        test = GetComponent<nextTabButton>();
        Body.text = "No. " + (test.flashCardCounter) + "/" + test.len;
    }
}
