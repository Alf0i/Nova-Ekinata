using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraRelogio : MonoBehaviour
{
    [SerializeField] private IniciaJogo ini;
    public Text timerText;
    public float contms;
    public float conts;
    public float contm;
    public float conth;

    void Start()
    {
        
        
        Time.timeScale = 1f;
        contms = 0;
        conts = 0;
        contm = 0;
        conth = 7;

        GameControl._PauseGeral = false;

    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("iniciador")) 
        { 
            if(ini.comecou)
            {
                GameControl._PauseGeral = false;
            }
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
        

        if (GameControl._PauseGeral == false)
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



    


}

