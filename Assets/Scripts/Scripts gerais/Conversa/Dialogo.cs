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
    public bool dialogoTerminado;

    public static Dialogo Diag;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        Diag = this;
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
        dialogoTerminado = false;

        StartCoroutine(Ditar());
    }

    IEnumerator Ditar()
    {
        var linha = linhas[index];
        textDialog.text = "";
        foreach (var c in linha)
        {
            textDialog.text += c;
            yield return new WaitForSeconds(_tempoLetra);
        }
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
            dialogoTerminado = true;
        }
    }
}
