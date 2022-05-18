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
    private bool sair = false;
    private bool sairconfirm = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            sair = false;
            slots = false;
            Main.SetActive(false);
            Options.SetActive(true);
            Slots.SetActive(slots);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            sair = true;
            slots = false;
            Main.SetActive(true);
            Options.SetActive(false);
            Slots.SetActive(slots);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
           
            sair = false;
            slots = true;
            Slots.SetActive(slots);
            Options.SetActive(false);
            Main.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Space) && slots == true)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKey(KeyCode.DownArrow) && sair == true)
        {
            Debug.LogWarning("Saindo");


        }

    }
}
    


/*else if (Input.GetKey(KeyCode.DownArrow) && sairconfirm == true)
        {
    Debug.LogWarning("Saindo...");
    Application.Quit();
    wait*/