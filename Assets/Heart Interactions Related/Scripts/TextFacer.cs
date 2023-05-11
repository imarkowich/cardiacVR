using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TextFacer : MonoBehaviour
{
    // line, heart, endpoint of line
    LineRenderer line;
    public GameObject endpoint_obj;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // set text's rotation to camera's rotation
        Quaternion cam = Camera.main.transform.rotation;
        transform.rotation = cam;

        // set line's position to label -> heart location
        Vector3 txt = transform.position;
        Vector3 end = endpoint_obj.transform.position;
        line.SetPosition(0, new Vector3(txt.x, txt.y - (float) 0.075, txt.z)); // card
        line.SetPosition(1, new Vector3(end.x, end.y, end.z)); // heart 
    }
}
