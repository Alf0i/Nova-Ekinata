using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI componenteDeTexto;
    public string[] linhas;
    public float velocidadeDeTexto;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        componenteDeTexto.text = string.Empty;
        ComeçarDialogo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (componenteDeTexto.text == linhas[index])
            {
                ProximaLinha();
            }
            else
            {
                StopAllCoroutines();
                componenteDeTexto.text = linhas[index];
            }
        }
    }

    void ComeçarDialogo()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in linhas[index].ToCharArray())
        {
            componenteDeTexto.text += c;
            yield return new WaitForSeconds(velocidadeDeTexto);
        }
    }

    void ProximaLinha()
    {
        if (index < linhas.Length - 1)
        {
            index++;
            componenteDeTexto.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}