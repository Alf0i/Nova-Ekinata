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

    [SerializeField] GameObject telaDeRequisito;

    public bool TemQuest;

    [SerializeField] int QuestID;

    [HideInInspector] public GerenciadorDeMissões G;


    public bool completo;
    private float dist;
    private bool _podeFalar;
    private bool _podeVerificarRequisitos;
    [HideInInspector] public bool IniciarMissão;

    [HideInInspector] public bool missãoIniciada;

    private void Awake()
    {
        Temp = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        _podeVerificarRequisitos = false;

        telaDeQuest.SetActive(false);

        telaDeRequisito.SetActive(false);

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
                        
                        if (!completo)
                        {
                            _podeVerificarRequisitos = true;
                            //if (G.missãoAtual.RequisitosCompletos())
//{


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
                            //}
                            // se nao tiver os prerequisitos nao aceita e mostra a tela de requisitos
                           /* else
                            {
                                FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                                telaDeRequisito.SetActive(true);

                                if (Input.GetKeyDown(KeyCode.Q))
                                {
                                    telaDeRequisito.SetActive(false);
                                    falar.dialogoTerminado = false;
                                    FindObjectOfType<PlayerController>()._playerSpeed = 8f;
                                }
                            }*/
                        }
                        else
                        {
                            falar.dialogoTerminado = false;
                        }
                    }
                    
                }
                else
                {
                    falar.dialogoTerminado = false;
                }
            }

        }

        if (_podeVerificarRequisitos)
        {
            //G.missãoAtual.RequisitosCompletos();
        }

        if (IniciarMissão == true)
        {
            missãoIniciada = true;
            G.ComeçarMissão();

            IniciarMissão = false;
        }


        if (Input.GetKeyDown(KeyCode.F) && _podeFalar == true)
        {
            falar.dialogoTerminado = false;
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