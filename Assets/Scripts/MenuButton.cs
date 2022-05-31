using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject slotsMenu;
    private bool menu = true, options = false, slots = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && menu == true)
        {
            options = true;
            menu = false;
            mainMenu.SetActive(menu);
            optionsMenu.SetActive(options);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && options == true)
        {
            options = false;
            menu = true;
            mainMenu.SetActive(menu);
            optionsMenu.SetActive(options);
        }
        else if (Input.GetKey(KeyCode.KeypadEnter) && menu == true)
        {
            slots = true;
            options = false;
            menu = false;
            mainMenu.SetActive(menu);
            slotsMenu.SetActive(slots);

        }
        else if (Input.GetKey(KeyCode.Escape) && slots == true)
        {
            menu = true;
            slots = false;
            mainMenu.SetActive(menu);
            slotsMenu.SetActive(options);
        }
    }
}


