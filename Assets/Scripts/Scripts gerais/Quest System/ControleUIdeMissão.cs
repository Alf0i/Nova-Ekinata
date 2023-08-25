using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleUIdeMissão : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI titulo;
    [SerializeField] private TextMeshProUGUI objetivoAtual;

    private TemplateFalaNPC T;
    private bool escrito;
    // Start is called before the first frame update
    void Start()
    {
        titulo.gameObject.SetActive(false);
        objetivoAtual.gameObject.SetActive(false);
        escrito = false;
    }

    // Update is called once per frame
    void Update()
    {
        //    titulo.gameObject.SetActive(GerenciadorDeMissões.missãoAtual != null);

        T = TemplateFalaNPC.Temp;

        if (T.G.missãoAtual != null && escrito == false && !T.G.missãoAtual.missaoPreparada)
        {
            titulo.gameObject.SetActive(false);
            objetivoAtual.gameObject.SetActive(false);
            
            
        }
        if (T.G.missãoAtual != null && T.G.missãoAtual.missaoPreparada)
        {
            titulo.gameObject.SetActive(true);
            objetivoAtual.gameObject.SetActive(true);
            titulo.text = "Missão: ";
            titulo.text += T.G.missãoAtual?.PegarNomeDeObjetivo();
            objetivoAtual.text = T.G.missãoAtual?.PegarDescriçãoDeObjetivo();
            escrito = true;
        }
        
        else if(T.G.missãoAtual == null && escrito)
        {
            titulo.gameObject.SetActive(false);
            objetivoAtual.gameObject.SetActive(false);
            titulo.text = " ";
            objetivoAtual.text = " ";
            escrito = false;
        }
        else if (T.G.missãoAtual == null && !escrito)
        {
            titulo.gameObject.SetActive(false);
            objetivoAtual.gameObject.SetActive(false);
            titulo.text = " ";
            objetivoAtual.text = " ";
            escrito = false;
        }

    }
}
