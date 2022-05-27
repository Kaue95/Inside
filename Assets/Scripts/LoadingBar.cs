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
    private float tempo = 0.2f;
    private float progressoatual = 0;

    private void Awake()
    {
        progressbar = gameObject.GetComponent<Slider>();
        StartCoroutine(Carrega());
    }

    IEnumerator Carrega()
    {
        if(progressbar.value != 2.0f) { 
            while (progressbar.value != 2.0f)
            {
                if (progressbar.value < 0.5f)
                {
                   
                    tempo = 0.2f;
                    
                }else if(progressbar.value > 0.5f && progressbar.value < 0.7f)
                {
                    Debug.Log("IF 1");
                    tempo = 1.0f;
                    
                }else if (progressbar.value > 1.0f && progressbar.value < 1.5f)
                {
                    Debug.Log("IF 1");
                    tempo = 1.0f;

                }








                progressbar.value += 0.02f;
                yield return new WaitForSeconds(tempo);

            }
        }
       
       if(progressbar.value == 2)
        {
            SceneManager.LoadScene(1);
        }

        
    }
    private void Update()
    {
     
    }

    //adicionando barra de progresso na barra 
    public void addprogress(float newprogress)
    {
       
        progressoatual = progressbar.value += newprogress;
       
    }

    
}
