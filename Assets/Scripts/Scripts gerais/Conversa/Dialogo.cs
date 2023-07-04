using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public static Dialogo dialog;
    
    
    public float velocidadeDeTexto;
    public bool _dialogoAtivo;
    private int index;
    public GameObject npc;
    private void Awake()
    {
        dialog = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        _dialogoAtivo = false;
        gameObject.SetActive(false);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TemplateFalaNPC.TemplFala.componenteDeTexto.text == TemplateFalaNPC.TemplFala.linhas[index])
            {
                ProximaLinha();
            }
            else
            {
                StopAllCoroutines();
                TemplateFalaNPC.TemplFala.componenteDeTexto.text = TemplateFalaNPC.TemplFala.linhas[index];
            }
        }
    }

    public void ComeçarDialogo()
    {
        gameObject.SetActive(true);
        _dialogoAtivo = true;
        index = 0;
        
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in TemplateFalaNPC.TemplFala.linhas[index].ToCharArray())
        {
            TemplateFalaNPC.TemplFala.componenteDeTexto.text += c;
            yield return new WaitForSeconds(velocidadeDeTexto);
        }
    }

    void ProximaLinha()
    {
        if (index < TemplateFalaNPC.TemplFala.linhas.Length - 1)
        {
            index++;
            TemplateFalaNPC.TemplFala.componenteDeTexto.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            TemplateFalaNPC.TemplFala.componenteDeTexto.text = string.Empty;
            _dialogoAtivo = false;
        }
    }
}