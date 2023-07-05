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


    //private bool dialogoIniciado;
    private bool linhaTerminada;


    private void Start()
    {

        gameObject.SetActive(false);
        // dialogoIniciado = false;
    }


    private void Update()
    {

        /*if(dialogoIniciado == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                AbrirDialogo(linhas);
            }
        }
        else
        {*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextPage();
        }
        //}


    }


    public void AbrirDialogo(string[] linhas)
    {
        FindObjectOfType<PlayerController>()._playerSpeed = 0f;

        if (gameObject.activeInHierarchy == true)
        {
            return;
        }
        //dialogoIniciado = true;
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


    private void NextPage()
    {
        if (linhaTerminada)
        {
            index++;
            if (index >= linhas.Length)
            {

                TerminarDialogo();
                return;
            }
            StartCoroutine(Ditar());
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
        StopCoroutine(Ditar());
    }

}
