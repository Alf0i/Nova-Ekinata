using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TemplateFalaNPC : MonoBehaviour
{
    [SerializeField] Dialogo falar;

    [TextArea(5, 8)]

    [SerializeField] string[] pages;

    [SerializeField] GameObject player;

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
                    G.IndexQuest = QuestID;
                    IniciarMissão = true;
                    falar.dialogoTerminado = false;

                    Debug.Log("G.indexQuest: " + G.IndexQuest);
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