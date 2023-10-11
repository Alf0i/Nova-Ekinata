using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    
    
    private Temporizador temp;
    private HighscoreTable hst;
    private bool finished = false;
    private bool _isPaused;
    public int pontos;
    public string nome;
    private Transform entryContainer;
    private Transform entryTemplate;

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
            
            pontos = (temp.min * 60) + temp.sec;

            nome = "AAA";

            Pausar();
        }
        
    }

    


    private void Pausar()
    {
        if (_isPaused == false)
        {
            Time.timeScale = 0f;
            _isPaused = true;
            hst.AddHighscoreEntry(pontos, nome);
        }
        else
        {
            Time.timeScale = 1f;
            _isPaused = false;
        }
    }
}
