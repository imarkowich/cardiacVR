using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSlideShow : MonoBehaviour
{
    public GameObject menu;
    public GameObject secondDisable;

    void Start()
    {

    }

    public void ToggleMenu() 
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            secondDisable.SetActive(true);
        }
        else {
            menu.SetActive(true);
            secondDisable.SetActive(false);
        }
        // Debug.Log("hello world");  
    }
}
