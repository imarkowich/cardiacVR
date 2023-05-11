using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class ScaleMax : MonoBehaviour
{
    float sliderVal;
    public GameObject holder_obj;
    public GameObject heart_main_obj;
    Vector3 objectScale;
    Vector3 heartS;

    // Start is called before the first frame update
    void Start()
    {
        sliderVal = GetComponent<Slider>().value;
        // Gets the local scale of game object
        objectScale = holder_obj.transform.lossyScale;
        heartS = heart_main_obj.transform.lossyScale;
    }

    public void DoScale()
    {
        sliderVal = GetComponent<Slider>().value;
        holder_obj.SetActive(false);
        // transform scale
        holder_obj.transform.localScale
            = new Vector3(objectScale.x * sliderVal, objectScale.y * sliderVal, objectScale.z * sliderVal);
        heart_main_obj.transform.localScale
            = new Vector3(heartS.x * sliderVal, heartS.y * sliderVal, heartS.z * sliderVal);
        holder_obj.SetActive(true);
    }

    public void Reset()
    {
        GetComponent<Slider>().value = 1;
        heart_main_obj.transform.localScale = heartS;
    }
}
