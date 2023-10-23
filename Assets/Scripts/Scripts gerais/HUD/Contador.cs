using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    private ScoreUI sc;
    private InfoPanelScore info;
    public GameObject scObj;
    public GameObject infoObj;

    public Temporizador temp;
    private bool finished = false;
    private bool _isPaused;
    private bool contado;
    private int pontos;
    int saveMin;
    int saveSec;

    // Start is called before the first frame update
    void Start()
    {
        contado = false;
        _isPaused = false;
        info = infoObj.GetComponent<InfoPanelScore>();
        sc = scObj.GetComponent<ScoreUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contado && !finished)
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                sc.Remover();
            }
        }
        
        //DELIGA O CONTADOR
        if (finished && _isPaused)
        {
            temp.lido = true;
            info.FecharTelaPlayer();
            if (info.telafechada)
            {
                
                sc.MostrarScore(info.n, pontos);
                finished = false;
            }
        }

        int Count = EntregaFinal._EntregaFinal.ContadorFinal;

        // TERMINA DE CONTAR
        if ((Count == 1 || Input.GetKeyDown(KeyCode.P)) && !contado && Time.timeScale == 1f)
        {
            contado = true;
            finished = true;
            Debug.Log("VOCE GANHOU");
            
            

            Pausar();
            info.MostrarTelaPlayer();
        }


        if (Input.GetKeyDown(KeyCode.Tab)) Pausar();
        
    }

    


    private void Pausar()
    {
        if (_isPaused == false)
        {
            
            pontos =  Mathf.FloorToInt((temp.remainingTime/ 60) + (temp.remainingTime));
            
            Time.timeScale = 0f;

            
            _isPaused = true;

        }
        
    }
}
