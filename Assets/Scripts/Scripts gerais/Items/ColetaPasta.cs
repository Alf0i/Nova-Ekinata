using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaPasta : MonoBehaviour
{
    public ColetaPasta _ColetaPasta;


    private float distancia;
    private bool _isNear;    
    public GameObject Player;
    

    private void Awake()
    {
        _ColetaPasta = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isNear = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //DISTANCIA DA PASTA

        if (distancia <= 1.5f)
        {
            _isNear = true;
        }
        else
        {
            _isNear = false;
        }

    }
    private void FixedUpdate()
    {
        Player.name = "Player";
        distancia = Vector2.Distance(gameObject.transform.position, Player.transform.position);

        


        //COLETA A PASTA
        if (ItemAdquirido._ItemAdquirido.itemColetado == false)
        {
            
            if (_isNear == true)
            {
                
                if (Input.GetKey(KeyCode.F))
                {
                    if(EntregaItems._entregaItems._exists == true)
                    {
                        EntregaItems._entregaItems._exists = false;

                        ItemAdquirido._ItemAdquirido.itemColetado = true;
                    ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.ItemPasta;
                        Debug.Log("PASTA coletada");
                        Destroy(EntregaItems._entregaItems.Obj);
                        
                    }     
                }
                
            }


        }   

        
    }
}
