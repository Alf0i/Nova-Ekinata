using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public int min;

    public int sec;
    public static Temporizador t;
    public Text timerText;
    private float startTime;
    private bool finished = false;
    private bool _isPaused;

    // Tempo total do temporizador em segundos
    public float totalTime = 60f;
    
    void Awake()
    {
        t = this;
    }
    void Start()
    {
        startTime = Time.time;
        _isPaused = false;
        Time.timeScale = 1f;
        
    }

    void Update()
    {
        //DELIGA O CONTADOR
        if (finished)
        {
            return;
        }

        float remainingTime = totalTime - (Time.time);

        // TERMINA DE CONTAR
        if (remainingTime < 1)
        {
            remainingTime = 0;
            finished = true;
            Debug.Log("Timer finished!");
            Pausar();
            

        }
       
        // DEFINI��ES DE VARIAVEIS
        min = Mathf.FloorToInt(remainingTime / 60f);
        sec = Mathf.FloorToInt(remainingTime % 60f);

        string timeString = string.Format("{0:00}:{1:00}", min, sec);

        timerText.text = timeString;
    }

    private void Pausar()
    {
        if(_isPaused == false)
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