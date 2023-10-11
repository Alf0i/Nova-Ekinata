using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    
    
    public Temporizador temp;
    public HighscoreTable hst;
    private bool finished = false;
    private bool _isPaused;
    public int pontos;
    public string nome;
    int saveMin;
    int saveSec;

    // Start is called before the first frame update
    void Start()
    {   
        _isPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //DELIGA O CONTADOR
        if (finished)
        {
            return;
        }

        float Count = EntregaFinal._EntregaFinal.ContadorFinal;

        // TERMINA DE CONTAR
        if (Count == 3)
        {
            Count = 0;
            finished = true;
            Debug.Log("VOCE GANHOU");
            
            

            Pausar();
        }


        if (Input.GetKeyDown(KeyCode.Tab)) Pausar();
        
    }

    


    private void Pausar()
    {
        if (_isPaused == false)
        {
            saveMin = temp.min;
            saveSec = temp.sec;
            pontos = (saveMin * 60) + saveSec;

            nome = "AAA";
            hst.AddHighscoreEntry(pontos, nome);
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
