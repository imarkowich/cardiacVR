using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashcardNumeroBack : MonoBehaviour
{
    // Start is called before the first frame update
    public nextTabButton test;
    public GameObject testy;
    public Text Body;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void setText()
    {
        test = testy.GetComponent<nextTabButton>();
        Body.text = "No. " + (test.flashCardCounter) + "/" + test.len;
    }
}
