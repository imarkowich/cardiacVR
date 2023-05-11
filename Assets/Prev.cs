using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prev : MonoBehaviour
{
    public GameObject current_slide;
    public GameObject prev_slide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        current_slide.SetActive(false);
        prev_slide.SetActive(true);
    }
}
