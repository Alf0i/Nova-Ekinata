using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecEntrega : MonoBehaviour
{
    public Color minhaCor;
    public Color CorDeAproximacao;

    private float distancia;
    public GameObject player;
    public float _UsingTime;

    public bool _canUse;
    private bool _isNear;
    // Start is called before the first frame update
    void Start()
    {
        _canUse = true;
        _isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (distancia <= 1.5f)
        {
            _isNear = true;
        }
        else
        {
            _isNear = false;
        }

        if (_isNear == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = CorDeAproximacao;
        }
    }

    void FixedUpdate()
    {
        distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);
        gameObject.GetComponent<SpriteRenderer>().color = minhaCor;
        Coletar();

    }

    private void Coletar()
    {
        // verifica se esta segurando algo
        if (ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.None)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
            }



            if (gameObject == GameObject.Find("Entrega"))
            {
                if (_isNear == true)
                {
                    

                    if (Input.GetKey(KeyCode.F))
                    {

                        if(EntregaItems._entregaItems.ItemRequisitadoCondicao == true)
                        {
                            if (ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.Tinta && ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.ItemA
                                && ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.ItemPasta)
                            {
                            
                                if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemB &&
                                    EntregaItems._entregaItems.ItemEntregueB == true) { }
                                else if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemC &&
                                    EntregaItems._entregaItems.ItemEntregueC == true) { }
                                else if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemD &&
                                    EntregaItems._entregaItems.ItemEntregueD == true) { }
                                else
                                {
                                    ItemAdquirido._ItemAdquirido.tipoItemEntregue = ItemAdquirido._ItemAdquirido.tipoItemColetado;
                                    ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                                    Debug.Log("item " + ItemAdquirido._ItemAdquirido.tipoItemEntregue + " entregue");
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }


}
