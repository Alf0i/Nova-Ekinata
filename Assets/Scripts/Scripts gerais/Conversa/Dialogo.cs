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
            if (textDialog.text == linhas[index])
            {
                NextPage();
            }

            else
            {
                StopAllCoroutines();
                textDialog.text = linhas[index];
            }
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

    public void AbrirQuest(string[] linhas)
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

        StartCoroutine(DitarQuest());
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
        linhas2 = missao._objetivo[index]._descricao;

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
                AbrirQuest(Quest.missao._nomeQuest);
                
                
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
