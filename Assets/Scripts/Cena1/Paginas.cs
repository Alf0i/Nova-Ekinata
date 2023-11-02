using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Pag 
{
    public Sprite _spr;
    public string texto;
}

public class Paginas : MonoBehaviour
{
    public List<Pag> pag; 
    private int index;
    [SerializeField] private Image _img;
    [SerializeField] private Text _txt;
    private IniciaJogo iniciador;
    private bool aberto;
    public bool iniciado;
    public GameObject explicacao;


    void Start()
    {
        aberto = true;
        iniciado = false;
        index = 0;
        iniciador = IniciaJogo.Ij;
        GameControl._PauseGeral = true;
    }

    // Update is called once per frame
    void Update()
    {
        _img.sprite = pag[index]._spr;
        _txt.text = pag[index].texto;
        EscolherPag();
        Abrir_Fechar();
        if (iniciado)
        {
            if (GameObject.FindGameObjectWithTag("iniciador")) {iniciador.gameObject.SetActive(true);
                iniciado = false;
            }
            
            
        }
    }
    void EscolherPag()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            if (index < pag.Count-1) index++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            if (index == 0) index = 0;
            else index--;
        }
    }

    void Abrir_Fechar()
    {
        if (aberto && iniciado)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Escape)) { 
                explicacao.SetActive(false);
                aberto = false;
                Time.timeScale = 1f;
            } 
        }
        else if(!aberto && iniciado)
        {
            
            if (Input.GetKeyDown(KeyCode.H)) {
            explicacao.SetActive(true);
            aberto = true;
                Time.timeScale = 0f;
            } 
        }
        else if (aberto && !iniciado)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                explicacao.SetActive(false);
                aberto = false;
                iniciado = true;
                Time.timeScale = 1f;
            }
        }
    }
}
