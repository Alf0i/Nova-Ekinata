using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TemplateFalaNPC : MonoBehaviour
{
    private MovimentoNpc mov;

    public static TemplateFalaNPC Temp;

    [SerializeField] TextMeshProUGUI titulo;

    [SerializeField] TextMeshProUGUI descricao;

    public Dialogo falar;

    [TextArea(5, 8)]

    [SerializeField] string[] pages;

    [SerializeField] string[] pagesAfterMission;

    private GameObject player;

    [SerializeField] GameObject telaDeQuest;

    [SerializeField] GameObject telaDeRequisito;

    public bool TemQuest;

    [SerializeField] int QuestID;

    [HideInInspector] public GerenciadorDeMissões G;


    public bool completo;
    private float dist;
    public float limiteDist;
    private bool _podeFalar;
    [HideInInspector] public bool IniciarMissão;
    private bool feito;
    [HideInInspector] public bool missãoIniciada;

    private void Awake()
    {
        Temp = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        feito = false;

        telaDeQuest.SetActive(false);

        telaDeRequisito.SetActive(false);

        IniciarMissão = false;

        missãoIniciada = false;

        _podeFalar = false;

        mov = gameObject.GetComponent<MovimentoNpc>();

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
                feito = false;
                IniciarMissão = false;
                missãoIniciada = false;
                this.completo = true;
                G.indexQuest = -1;
                G.missãoAtual = null;
            }
        }
        if (missãoIniciada == false)
        {
            if (dist <= limiteDist)
            {
                if (falar.dialogoTerminado == true)
                {


                    if (TemQuest == true)
                    {
                        
                        if (!completo)
                        {
                            FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                                
                            G.IndexQuest = QuestID;
                            G.missãoAtual = G.missões[G.indexQuest];
                            
                            G.missãoAtual.RequisitosCompletos();


                            if (G.missãoAtual.RequisitosCompletos())
                            {
                                telaDeQuest.SetActive(true);
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
                                    if (gameObject.GetComponent<MovimentoNpc>() != null) mov.ContinuaMov();
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
                                    if (gameObject.GetComponent<MovimentoNpc>() != null) mov.ContinuaMov();
                                }
                            }
                            // se nao tiver os prerequisitos nao aceita e mostra a tela de requisitos
                            else
                            {

                                FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                                telaDeRequisito.SetActive(true);

                                if (Input.GetKeyDown(KeyCode.Q))
                                {
                                    telaDeRequisito.SetActive(false);
                                    falar.dialogoTerminado = false;
                                    FindObjectOfType<PlayerController>()._playerSpeed = 8f;
                                    G.IndexQuest = -1;
                                    if (gameObject.GetComponent<MovimentoNpc>() != null) mov.ContinuaMov();
                                }
                            }
                        }
                        else
                        {
                            falar.dialogoTerminado = false;
                            //TemQuest = false;
                        }
                    }
                    else
                    {
                        falar.dialogoTerminado = false;
                        if (gameObject.GetComponent<MovimentoNpc>() != null) mov.ContinuaMov();
                    }

                }
                else
                {
                    falar.dialogoTerminado = false;
                }
            }

        }





        if (IniciarMissão == true && feito == false)
            {
                missãoIniciada = true;
                G.ComeçarMissão();

                feito = true;
            }
        

        //momentos em que pode falar com o npc
        if (Input.GetKeyDown(KeyCode.F) && _podeFalar == true)
        {
            if(gameObject.GetComponent<MovimentoNpc>() != null) { mov.ParaMov(); }
            

            falar.dialogoTerminado = false;
            if (!completo && TemQuest && !falar.dialogoTerminado)
            {
                falar.AbrirDialogo(pages);
            }
            else if(completo && TemQuest && !falar.dialogoTerminado)
            {
                falar.AbrirDialogo(pagesAfterMission);
            }
            else if (!completo && !TemQuest && !falar.dialogoTerminado)
            {
                falar.AbrirDialogo(pages);
            }

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