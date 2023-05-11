using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationMax : MonoBehaviour
{
    float sliderVal;
    public float defaultRotation;
    public GameObject holder_obj;

    // Start is called before the first frame update
    void Start()
    {
        sliderVal = GetComponent<Slider>().value;
    }

    public void DoRotation()
    {
        sliderVal = GetComponent<Slider>().value;
        //holder.transform.Rotate(0, sliderVal, 0);
        holder_obj.transform.rotation = Quaternion.Euler(0, sliderVal, 0);
    }
    public void Reset()
    {
        GetComponent<Slider>().value = defaultRotation;
    }
}
