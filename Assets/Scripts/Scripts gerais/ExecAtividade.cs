using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecAtividade : MonoBehaviour
{
    public static ExecAtividade _ExecAtividade;
    public Color minhaCor;
    public Color CorDeAproximacao;

    private float distancia;
    public GameObject player;
    public float _UsingTime;
   
    public bool _canUse;
    private bool _isUsingObj;
    public float _CurrentTime;
    private bool _isNear;

    public GameObject obj2;
    public GameObject prefabCheck;
    private void Awake()
    {
        _ExecAtividade = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<SpriteRenderer>().color = minhaCor;

        _canUse = true;
        _isUsingObj = false;
        _CurrentTime = 0f;
        
        
        _isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == GameObject.Find("Camera fotografica"))
        {
            

            if (distancia <= 1f)
            {
                _isNear = true;
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "up";
            }
            else
            {
                _isNear = false;
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }
        else
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


        if (_isNear == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {


                _isUsingObj = true;
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {


                _isUsingObj = false;
            }
        }

        
    }
    void FixedUpdate()
    {
        distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);
        
        Coletar();
        
    }

    private void Coletar()
    {
        // se tiver dentro da area do objeto utlizar o "F" vai fazer a fun��o do objeto.
        if (_isNear == true)
        {

            if (_isUsingObj == true)
            {
                if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.None)
                {
                   
                    _CurrentTime += Time.deltaTime;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                    // APOS O TEMPO DE USO COLETA ITEM
                    if (_CurrentTime >= _UsingTime)
                    {


                        if (gameObject == GameObject.Find("Camera fotografica"))
                        {

                            ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.ItemA;
                            Debug.Log("item A coletado");
                            obj2 = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(1f, 1f, 0f), prefabCheck.transform.rotation) as GameObject;
                            obj2.name = "check";
                            Destroy(obj2, 3f);
                        }

                        else if (gameObject == GameObject.Find("Assinatura"))
                        {
                            ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.ItemB;
                            Debug.Log("item B coletado");
                            obj2 = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(1f, 1f, 0f), prefabCheck.transform.rotation) as GameObject;
                            obj2.name = "check";
                            Destroy(obj2, 3f);
                        }

                        else if (gameObject == GameObject.Find("Digital"))
                        {
                            ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.ItemC;
                            Debug.Log("item C coletado");
                            obj2 = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(1f, 1f, 0f), prefabCheck.transform.rotation) as GameObject;
                            obj2.name = "check";
                            Destroy(obj2, 3f);

                        }

                        _isUsingObj = false;
                        _CurrentTime = 0f;
                    }
                    

                }
            }
            // IDENTIFICADOR DE APROXIMACAO
            else if (_isUsingObj == false)
            {
                    gameObject.GetComponent<SpriteRenderer>().color = CorDeAproximacao;
            }

            
            

            if (ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.None)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                }

            }
        }    // O QUE OCORRE QUANDO ESTA LONGE
        else if (_isNear == false)
        {

                _isUsingObj = false;
                gameObject.GetComponent<SpriteRenderer>().color = minhaCor;
            if (ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.None)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                }
            }
        }

            
        
        

    }
}
