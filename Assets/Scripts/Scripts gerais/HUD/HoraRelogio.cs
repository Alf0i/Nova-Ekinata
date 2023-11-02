using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraRelogio : MonoBehaviour
{
    [SerializeField] private Paginas pag;
    public Text timerText;
    public float contms;
    public float conts;
    public float contm;
    public float conth;
    private bool _isPaused;

    void Start()
    {
        Debug.Log("COME�OU");
        
        Time.timeScale = 1f;
        contms = 0;
        conts = 0;
        contm = 0;
        conth = 7;

        _isPaused = false;
        GameControl._PauseGeral = false;

    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("paginas")) 
        { 
            if(pag.iniciado)
            {
                GameControl._PauseGeral = false;
            }
        }
        // PAUSE 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();

        }
        string timeString = string.Format("{0:00}:{1:00}", conth, contm);

        timerText.text = timeString;
    }
    private void FixedUpdate()
    {
        ContarHoras();
    }

    private void ContarHoras()
    {
        

        if (_isPaused == false)
        {

            contms += (Time.fixedDeltaTime*60);
            
            if (conth == 23 && contm == 59 && conts == 59 && contms >=1.875
            )
            {
                //Debug.Log("UM DIA");
                conth = 0;
                contm = 0;
                conts = 0;
                contms = 0;

            }
            else if (contm == 59 && conts == 59 && contms >=1.875
            )
            {
                //Debug.Log("UMA HORA");
                conth ++;
                contm = 0;
                conts = 0;
                contms = 0;

            }
            else if (conts == 59 && contms >=1.875
            )
            {   
                //Debug.Log("UM MINUTO");
                contm++;
                conts = 0;
                contms = 0;
                
            }
            else if (contms >=1.875
            )
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

