using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    private ScoreUI sc;
    private InfoPanelScore info;
    public GameObject scObj;
    public GameObject infoObj;
    public int min;

    public int sec;
    public static Temporizador t;
    public Text timerText;
    private float startTime;
    private bool finished = false;
    private bool _isPaused;
    public bool lido;
    public float remainingTime;

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
        info = infoObj.GetComponent<InfoPanelScore>();
        sc = scObj.GetComponent<ScoreUI>();
        lido = false;
    }

    void Update()
    {
        //DELIGA O CONTADOR
        if (finished && _isPaused && !lido)
        {
            
            sc.MostrarScoreSemPontos();
            finished = false;
            lido = true;
        }

        remainingTime = totalTime - (Time.time);

        // TERMINA DE CONTAR
        if ((remainingTime < 1 || Input.GetKeyDown(KeyCode.M)) && Time.timeScale == 1f)
        {
            remainingTime = 0;
            finished = true;
            Debug.Log("Timer finished!");
            Pausar();

            //info.MostrarTelaPlayer();


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
        
    }
}