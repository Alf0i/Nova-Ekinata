using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraRelogio : MonoBehaviour
{
    public Text timerText;

    private float contms;
    private float conts;
    private float contm;
    private float conth;
    private bool _isPaused;




    void Start()
    {
        Debug.Log("COMEÇOU");
        
        Time.timeScale = 1f;
        contms = 0;
        conts = 0;
        contm = 0;
        conth = 7;

        _isPaused = false;
        

    }

    void Update()
    {

        // PAUSE 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();

        }

    }
    private void FixedUpdate()
    {
        ContarHoras();
    }

    private void ContarHoras()
    {
        

        if (_isPaused == false)
        {

            contms += (Time.deltaTime*60);
            Debug.Log(conth + " : " + contm);
            if (conth == 23 && contm == 59 && conts == 59 && contms >= 3.59)
            {
                Debug.Log("UM DIA");
                conth = 0;
                contm = 0;
                conts = 0;
                contms = 0;

            }
            else if (contm == 59 && conts == 59 && contms >= 3.59)
            {
                Debug.Log("UMA HORA");
                conth ++;
                contm = 0;
                conts = 0;
                contms = 0;

            }
            else if (conts == 59 && contms >= 3.59)
            {   
                Debug.Log("UM MINUTO");
                contm++;
                conts = 0;
                contms = 0;
                
            }
            else if (contms >= 3.59)
            {
                                
                conts++;
                contms = 0;
                
            }
            
        }
    }



    private void Pausar()
    {
        if (_isPaused == false)
        {
            Time.timeScale = 0f;
            _isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            _isPaused = false;
        }
    }


}

