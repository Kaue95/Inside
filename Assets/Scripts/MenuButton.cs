using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    public GameObject Main;
    public GameObject Options;
    public GameObject Slots;
    private bool slots = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            slots = false;
            Main.SetActive(false);
            Options.SetActive(true);
            Slots.SetActive(slots);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            slots = false;
            Main.SetActive(true);
            Options.SetActive(false);
            Slots.SetActive(slots);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            slots = true;
            Slots.SetActive(slots);
            Options.SetActive(false);
            Main.SetActive(false);
           
        }

        if (Input.GetKeyDown(KeyCode.Space) && slots == true)
        {
            SceneManager.LoadScene(1);
        }

        }

    }

