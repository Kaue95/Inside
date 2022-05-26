using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadingBar : MonoBehaviour
{
    private Slider progressbar;
    public float Speed = 0.01f;
    private float progressoatual = 0;
    private float seg = 0.5f;
    private void Awake()
    {
        progressbar = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        addprogress(0.75f);
            if(progressoatual == 2.0f)
        {
            SceneManager.LoadScene(1);
        }
       
    }

    private void Update()
    {
        
        if (progressbar.value < progressoatual)
        {
            
            progressbar.value += Speed = Time.deltaTime;
        }


    }

    //adicionando barra de progresso na barra 
    public void addprogress(float newprogress)
    {
       
        progressoatual = progressbar.value += newprogress;
       
    }

    
}
