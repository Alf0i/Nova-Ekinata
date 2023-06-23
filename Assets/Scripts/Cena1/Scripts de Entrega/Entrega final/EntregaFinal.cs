using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntregaFinal : MonoBehaviour
{
    public static EntregaFinal _EntregaFinal;
    public Text Text;
    public int ContadorFinal;
    private float distancia;
    public GameObject player;
    private bool _isNear;

    private void Awake()
    {
        _EntregaFinal = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ContadorFinal = 0;
        _isNear = false;
        setCountText();
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

    }

    private void FixedUpdate()
    {
        distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);
        EntregandoPasta();
        setCountText();
    }


    private void EntregandoPasta()
    {
        if(gameObject == GameObject.Find("EntregaFinal"))
        {
            if (_isNear == true)
            {


                if (Input.GetKey(KeyCode.F))
                {

                    if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemPasta)
                    {
                        ItemAdquirido._ItemAdquirido.tipoItemEntregue = ItemAdquirido._ItemAdquirido.tipoItemColetado;
                        ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                        Debug.Log(ItemAdquirido._ItemAdquirido.tipoItemEntregue + " entregue");

                        ContadorFinal += 1;
                        Debug.Log("Contagem: " + ContadorFinal);
                    }
                }
            }
        }
    }

    public void setCountText()
    {
        Text.text = ContadorFinal.ToString();
    }
    
}
