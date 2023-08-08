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
    private bool linhaTerminada;

    private void Start()
    {
        gameObject.SetActive(false);
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

    private void NextPage()
    {
        if (index < linhas.Length - 1)
        {
            index++;
            textDialog.text = string.Empty;
            StartCoroutine(Ditar());
        }
        
        else
        {
            FindObjectOfType<PlayerController>()._playerSpeed = 8f;
            gameObject.SetActive(false);
            StopCoroutine(Ditar());
        }
    }
}
