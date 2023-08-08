using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleUIdeMissão : MonoBehaviour
{
    
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI objetivoAtual;

    private GerenciadorDeMissões gerenciadorDeMissões;
    
    // Start is called before the first frame update
    void Start()
    {
        gerenciadorDeMissões = FindObjectOfType<GerenciadorDeMissões>();
    }

    // Update is called once per frame
    void Update()
    {
    //    titulo.gameObject.SetActive(GerenciadorDeMissões.missãoAtual != null);
    //    titulo.text += GerenciadorDeMissões.missãoAtual; 
    //
    //    objetivoAtual.text = GerenciadorDeMissões.missãoAtual?.PegarDescriçãoDeObjetivo();
    }
}
