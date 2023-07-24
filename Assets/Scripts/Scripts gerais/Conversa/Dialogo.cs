using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    [SerializeField] float _tempoLetra;
    [SerializeField] TextMeshProUGUI textDialog;
    private string[] linhas;
    private int index;
    public Quest missao;
    private string linhas2;
    [SerializeField] GameObject infoQuest;

    private bool linhaTerminada;
    private bool escreveuQuest;

    private void Start()
    {

        gameObject.SetActive(false);
        escreveuQuest = false;
    }


    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextPage();
        }

        if (escreveuQuest)
        {   if (Input.GetKeyDown(KeyCode.E))
            {
                Quest.missao._questIniciada = true;
                TerminarDialogo();
                escreveuQuest = false;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                TerminarDialogo();
                escreveuQuest = false;
            }
        }
    }


    public void AbrirDialogo(string[] linhas)
    {
        FindObjectOfType<PlayerController>()._playerSpeed = 0f;

        if (gameObject.activeInHierarchy == true)
        {
            return;
        }
        
        gameObject.SetActive(true);
        this.linhas = linhas;
        index = 0;
        linhaTerminada = false;

        StartCoroutine(Ditar());
    }


    IEnumerator Ditar()
    {
        var linha = linhas[index];
        textDialog.text = "";
        linhaTerminada = false;
        foreach (var c in linha)
        {
            textDialog.text += c;
            yield return new WaitForSeconds(_tempoLetra);
        }
        linhaTerminada = true;
    }

    IEnumerator DitarQuest()
    {
        linhas2 = Quest.missao._objetivo[Quest.missao.i]._descricao;

        textDialog.text = "";
        linhaTerminada = false;
        foreach (var c in linhas2)
        {
            textDialog.text += c;
            yield return new WaitForSeconds(_tempoLetra);
        }
        linhaTerminada = true;
        escreveuQuest = true;
        infoQuest.SetActive(true);
    }


    private void NextPage()
    {
        if (linhaTerminada)
        {

            
            if (index >= linhas.Length - 1)
            {
                TerminarDialogo();
                AbrirDialogo(Quest.missao._nomeQuest);
                StartCoroutine(DitarQuest());
                
            }
            else
            {   
                index++;
                StartCoroutine(Ditar());
            }
            
        }
        else
        {
            linhaTerminada = true;
            textDialog.text = linhas[index];
            StopCoroutine(Ditar());
        }

    }



    public void TerminarDialogo()
    {
        FindObjectOfType<PlayerController>()._playerSpeed = 8f;

        //dialogoIniciado = false;
        gameObject.SetActive(false);
        infoQuest.SetActive(false);
        StopCoroutine(DitarQuest());
        StopCoroutine(Ditar());
    }

}
