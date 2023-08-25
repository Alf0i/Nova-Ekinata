using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TemplateFalaNPC : MonoBehaviour
{
    public static TemplateFalaNPC Temp;

    [SerializeField] TextMeshProUGUI titulo;

    [SerializeField] TextMeshProUGUI descricao;

    public Dialogo falar;

    [TextArea(5, 8)]

    [SerializeField] string[] pages;

    private GameObject player;

    [SerializeField] GameObject telaDeQuest;

    public bool TemQuest;

    [SerializeField] int QuestID;

    [HideInInspector] public GerenciadorDeMissões G;


    public bool completo;
    private float dist;
    private bool _podeFalar;
    [HideInInspector] public bool IniciarMissão;
    
    [HideInInspector] public bool missãoIniciada;

    private void Awake()
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

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (G.indexQuest == QuestID)
        {
            if (G.missãoAtual.completado)
            {
                missãoIniciada = false;
                this.completo = true;
                G.indexQuest = -1;
                G.missãoAtual = null;
            }
        }
        if (missãoIniciada == false)
        {
            if (dist <= 2)
            {
                if (falar.dialogoTerminado == true)
                {


                    if (TemQuest == true)
                    {
                        if (!completo) {
                            FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                            telaDeQuest.SetActive(true);
                            G.IndexQuest = QuestID;
                            G.missãoAtual = G.missões[G.indexQuest];
                            titulo.text = G.missãoAtual?.PegarNomeDeObjetivo();
                            descricao.text = G.missãoAtual?.PegarDescriçãoDeObjetivo();

                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                titulo.text = " ";
                                descricao.text = " ";
                            
                                IniciarMissão = true;
                                falar.dialogoTerminado = false;
                                telaDeQuest.SetActive(false);
                                FindObjectOfType<PlayerController>()._playerSpeed = 8f;

                                Debug.Log("G.indexQuest: " + G.IndexQuest);
                            }
                            else if (Input.GetKeyDown(KeyCode.Q))
                            {
                                G.missãoAtual = null;
                                G.IndexQuest = -1;
                                titulo.text = " ";
                                descricao.text = " ";
                                telaDeQuest.SetActive(false);
                                falar.dialogoTerminado = false;
                                FindObjectOfType<PlayerController>()._playerSpeed = 8f;
                            }
                        }
                        else
                        {
                            falar.dialogoTerminado = false;
                        }
                    }
                    else
                    {
                        falar.dialogoTerminado = false;
                    }
                }
            }

        
            if (IniciarMissão == true)
            {   
                missãoIniciada = true;
                G.ComeçarMissão();
                
                IniciarMissão = false;
            }
        }
        else
        {
            
                falar.dialogoTerminado = false;
            
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