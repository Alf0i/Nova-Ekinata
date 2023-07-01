using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraRelogio : MonoBehaviour
{
    public Text timerText;
    private float contsh;
    private float contms;
    private float conts;
    private float contm;
    private float conth;
    private bool _isPaused;
    private int x;



    void Start()
    {
        Debug.Log("COMEÇOU");
        
        Time.timeScale = 1f;
        contsh += Time.timeScale;
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

            

            
            if (conth == 23 && contm == 59 && conts == 59 && contms == 59 && contsh >= 4)
            {
                conth = 0;
                contm = 0;
                conts = 0;
                contms = 0;
                contsh = 0;
            }
            else if (contm == 23 && conts == 59 && contms == 59 && contsh >= 1.875)
            {
                Debug.Log("UM DIA");
                contm = 0;
                conts = 0;
                contms = 0;
                contsh = 0;
            }
            else if (conts == 59 && contms == 59 && contsh >= 1.875)
            {
                Debug.Log("UMA HORA");
                contm++;
                conts = 0;
                contms = 0;
                contsh = 0;
            }
            else if (contms == 59 && contsh >= 1.875)
            {
                Debug.Log("UM MINUTO");
                conts++;
                contms = 0;
                contsh = 0;
            }
            else if (contsh >= 1.875)
            {
                
                contms++;
                contsh = 0;
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

