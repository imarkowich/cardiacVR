using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleSettings : MonoBehaviour
{
    public InputActionReference toggleSettings = null;
    public GameObject menu = null;

    void Awake()
    {
        toggleSettings.action.started += ToggleMenu;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        if (menu.activeInHierarchy)
            menu.SetActive(false);
        else
            menu.SetActive(true);
    }
}
