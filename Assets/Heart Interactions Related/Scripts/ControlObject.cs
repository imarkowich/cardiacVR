using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ControlObject : MonoBehaviour
{
    public GameObject heart_main_obj;
    public GameObject holder_obj;
    public GameObject anatomy_btn_obj;
    Vector3 holderPosition;
    Image anatomy_btn;
    Animator anatomyAnim;
    Rigidbody heart_rb;

    // colors
    public Color selectedColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
    public Color deselectedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        holderPosition = holder_obj.GetComponent<Transform>().position;
        anatomyAnim = heart_main_obj.GetComponent<Animator>();
        heart_rb = heart_main_obj.GetComponent<Rigidbody>();
        anatomy_btn = anatomy_btn_obj.GetComponent<Image>();

        // teleport on start
        TeleportHeart();
    }

    public void TeleportHeart()
    {
        heart_rb.velocity = Vector3.zero;
        heart_main_obj.transform.position = holderPosition;
    }

    public void ToggleAnatomy()
    {
        bool myBool = anatomyAnim.GetBool("HasAnatomy");
        if (myBool == true)
        {
            anatomyAnim.SetBool("HasAnatomy", false);
            anatomy_btn.color = deselectedColor;
        }
        else
        {
            anatomyAnim.SetBool("HasAnatomy", true);
            anatomy_btn.color = selectedColor;
        }

    }
}
