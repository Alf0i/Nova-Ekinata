using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class TelaDeMissao
{
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI descricao;
}

public class TemplateFalaNPC : MonoBehaviour
{
    [SerializeField] TelaDeMissao Tela;

    [SerializeField] Dialogo falar;

    [TextArea(5, 8)]

    [SerializeField] string[] pages;

    [SerializeField] GameObject player;

    [SerializeField] GameObject telaDeQuest;

    public bool TemQuest;

    [SerializeField] int QuestID;

    public GerenciadorDeMissões G;

    public static TemplateFalaNPC Temp;



    private float dist;
    private bool _podeFalar;
    public bool IniciarMissão;
    
    public bool missãoIniciada;

    void Awake()
    {
        Temp = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        telaDeQuest.SetActive(false);

        IniciarMissão = false;

        missãoIniciada = false;

        _podeFalar = false;

        G = GerenciadorDeMissões.Gerencia;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if(dist <= 2)
        {
            if (falar.dialogoTerminado == true)
            {


                if (TemQuest == true)
                {   
                    FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                    telaDeQuest.SetActive(true);
                    Tela.titulo.text += G.missãoAtual?.PegarNomeDeObjetivo();
                    Tela.descricao.text += G.missãoAtual?.PegarDescriçãoDeObjetivo();
                    
                    if (Input.GetKeyDown(KeyCode.E)) {
                        Tela.titulo.text = " ";
                        Tela.descricao.text = " ";
                        G.IndexQuest = QuestID;
                        IniciarMissão = true;
                        falar.dialogoTerminado = false;
                        telaDeQuest.SetActive(false);
                        FindObjectOfType<PlayerController>()._playerSpeed = 8f;

                        Debug.Log("G.indexQuest: " + G.IndexQuest);
                    }
                    else if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Tela.titulo.text = " ";
                        Tela.descricao.text = " ";
                        telaDeQuest.SetActive(false);
                        falar.dialogoTerminado = false;
                        FindObjectOfType<PlayerController>()._playerSpeed = 8f;
                    }
                }
            }
        }

        if (missãoIniciada == false)
        {
            if (IniciarMissão == true)
            {   
                missãoIniciada = true;
                G.ComeçarMissão();
                
                IniciarMissão = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && _podeFalar == true)
        {

            falar.AbrirDialogo(pages);    

        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _podeFalar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _podeFalar = false;
        }
    }

}