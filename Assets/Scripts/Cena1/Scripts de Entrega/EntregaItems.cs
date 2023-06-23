using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntregaItems : MonoBehaviour
{
    public static EntregaItems _entregaItems;

    public GameObject Obj;
    public GameObject Obj2;
    

    public GameObject _InstPasta;
    public GameObject _InstReq;
    public Transform _TrPasta;
    public Transform _posicaoInstancia;

    public bool ItemEntregueA;
    public bool ItemEntregueB;
    public bool ItemEntregueC;
    public bool ItemEntregueD;

    public bool solicitado;
    public int solicitadocount;
    public bool ItemRequisitadoCondicao;

    public List<string> ListaItems = new List<string>{"B", "C", "D"};
    public int i;

    public bool _exists;

    private void Awake()
    {
        _entregaItems = this;
    }

    void Start()
    {
        ItemEntregueA = false;
        ItemEntregueB = false;
        ItemEntregueC = false;
        ItemEntregueD = false;
        _exists = false;

        ItemRequisitadoCondicao = false;
        solicitadocount = 0;

        Randomizar();
    }

    void Update()
    {

        

        ValidadorEntrega();
        GerarPastaEntrega();
        MostrarRequisito();
        

        if (ListaItems[i] == "B"  && ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemB)
        {
            ItemRequisitadoCondicao = true;  
              
        } 

        if (ListaItems[i] == "C"  && ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemC)
        {
            ItemRequisitadoCondicao = true;
              
        }

        if (ListaItems[i] == "D"  && ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemD)
        {
            ItemRequisitadoCondicao = true;   
            
        }

        
    }

    private void MostrarRequisito()
    {
        
        if (ListaItems[i] == "B")
        {
            if (ListaItems[i] != null && solicitado == false)
            {
                solicitadocount++;
                if (solicitadocount == 1)
                {
                    Obj2 = Instantiate(_InstReq, _posicaoInstancia.transform.position, _posicaoInstancia.rotation) as GameObject;
                    RequisitoSprite._reqSprite.GetComponent<SpriteRenderer>().sprite = RequisitoSprite._reqSprite._reqB;
                    Obj2.name = "Requisito";
                    Debug.Log(ListaItems[i]);
                    solicitado = true;
                    solicitadocount = 0;
                }

            }
            
        }

        else if (ListaItems[i] == "C")
        {
            if (ListaItems[i] != null && solicitado == false)
            {
                solicitadocount++;
                if (solicitadocount == 1)
                {
                    Obj2 = Instantiate(_InstReq, _posicaoInstancia.transform.position, _posicaoInstancia.rotation) as GameObject;
                    RequisitoSprite._reqSprite.GetComponent<SpriteRenderer>().sprite = RequisitoSprite._reqSprite._reqC;
                    Obj2.name = "Requisito";
                    Debug.Log(ListaItems[i]);
                    solicitado = true;
                    solicitadocount = 0;
                }

            }
            
        }

        else if (ListaItems[i] == "D")
        {
            if (ListaItems[i] != null && solicitado == false)
            {
                solicitadocount++;
                if (solicitadocount == 1)
                {
                    Obj2 = Instantiate(_InstReq, _posicaoInstancia.transform.position, _posicaoInstancia.rotation) as GameObject;
                    RequisitoSprite._reqSprite.GetComponent<SpriteRenderer>().sprite = RequisitoSprite._reqSprite._reqD;
                    Obj2.name = "Requisito";
                    Debug.Log(ListaItems[i]);
                    solicitado = true;
                    solicitadocount = 0;
                }

            }
            
        }

        
    }

    
    
    public void Randomizar()
    {        
        i = 0;
        
        for (int j = 0; j < ListaItems.Count; j++) 
        {
            string temp = ListaItems[j];
            int randomIndex = Random.Range(j, ListaItems.Count);
            ListaItems[j] = ListaItems[randomIndex];
            ListaItems[randomIndex] = temp;
        }

    }
    
    private void ValidadorEntrega()
    {
        {
            if (ItemAdquirido._ItemAdquirido.tipoItemEntregue == ItemAdquirido.TipoItem.ItemB)
            {
                ItemEntregueB = true;
                ItemAdquirido._ItemAdquirido.tipoItemEntregue = ItemAdquirido.TipoItem.None;
                ItemRequisitadoCondicao = false;
                i++;
                solicitado = false;
                Destroy(Obj2);
            }

            else if (ItemAdquirido._ItemAdquirido.tipoItemEntregue == ItemAdquirido.TipoItem.ItemC)
            {
                ItemEntregueC = true;
                ItemAdquirido._ItemAdquirido.tipoItemEntregue = ItemAdquirido.TipoItem.None;
                ItemRequisitadoCondicao = false;
                i++;
                solicitado = false;
                Destroy(Obj2);
            }

            else if (ItemAdquirido._ItemAdquirido.tipoItemEntregue == ItemAdquirido.TipoItem.ItemD)
            {
                ItemEntregueD = true;
                ItemAdquirido._ItemAdquirido.tipoItemEntregue = ItemAdquirido.TipoItem.None;
                ItemRequisitadoCondicao = false;
                i++;
                solicitado = false;
                Destroy(Obj2);
            }
        }
        

    }

    private void GerarPastaEntrega()
    {
        if (ItemEntregueB && ItemEntregueC && ItemEntregueD == true)
        {
            Obj = Instantiate(_InstPasta, _TrPasta.position, _TrPasta.rotation) as GameObject;
            Obj.name = "Pasta";

            _exists = true;

            ItemEntregueB = false;
            ItemEntregueC = false;
            ItemEntregueD = false;

            Randomizar();
        }
    }

    


    
}    

