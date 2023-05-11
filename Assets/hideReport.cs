using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideReport : MonoBehaviour
{
    public bool flag;
    public GameObject toggle;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
   public void doHide()
   {
        if(flag == false)
        {
            flag = true;
            btn.SetActive(true);
            toggle.SetActive(true);
        }
        else
        {
            btn.SetActive(false);
            toggle.SetActive(false);
            flag = false;
        }
   }
}
