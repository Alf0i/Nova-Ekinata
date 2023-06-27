using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraRelogio : MonoBehaviour
{
    public Text timerText;
    private float initialTime;
    private bool _isPaused;

    // Tempo total do temporizador em segundos
    public float secTime;
    public float minTime;
    public float hourTime;

    void Start()
    {
        secTime = Time.time * 4;
        minTime = 0f;
        hourTime = 0f;
        _isPaused = false;
        Time.timeScale = 1f;

    }

    void Update()
    {
        Pausar();
    }

    private void FixedUpdate()
    {
        
    

        float remainingTime = initialTime + (secTime);

            // TERMINA DE CONTAR
            if (remainingTime > 59f)
            {
                remainingTime = 0;
                minTime++;
            
            


            }

            // DEFINIÇÕES DE VARIAVEIS
            int min = Mathf.FloorToInt(remainingTime / 60f);
            int sec = Mathf.FloorToInt(remainingTime);

            string timeString = string.Format("{0:00}:{1:00}", min, sec);

            timerText.text = timeString;
    }

    private void Pausar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
}

