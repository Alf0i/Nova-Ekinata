using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecImpressora : MonoBehaviour
{
    public static ExecImpressora _ExecImpressora;
    public Color minhaCor;
    public Color CorDeAproximacao;

    private float distancia;
    public GameObject player;
    public float _UsingTime;

    public bool _canUse;
    public bool _isUsingObj;
    public float _CurrentTime;
    private float _CurrentTimeCanUse;
    public bool _isNear;
    public float _canUseTime;
    public int Instantiatecount;

    public GameObject _InstReq;
    public GameObject Obj;
    public Transform _posicaoInstancia;

    public GameObject objCheck;
    public GameObject prefabCheck;

    private GameObject objFoto;
    public GameObject prefabFoto;
    public Transform _posicaoInstanciaFoto;

    public GameObject Fotografo;
    private Animator AnimFot;
    

    private void Awake()
    {
        _ExecImpressora = this;
    }

    // Start is called before the first frame update
    void Start()
    {


        Instantiatecount = 0;
        _canUse = true;
        _isUsingObj = false;
        _CurrentTimeCanUse = 0f;
        _CurrentTime = 0f;
        
        

        _isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimFot = Fotografo.GetComponent<Animator>();
        if (distancia <= 1.5f)
                {
                    _isNear = true;
         }
         else
                {
                    _isNear = false;
         }

        if (_isNear == true && _canUse)
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
        if (!GameControl._PauseGeral)
        {
            distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);

            Coletar();
            TempoDeFuncionamento();
        }
    }

    private void Coletar()
    {
        
        // se tiver dentro da area do objeto utlizar o "F" vai fazer a funcao do objeto.
        if (_isNear == true )
        {

            if (_isUsingObj == true)
            {
                if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemA)
                {
                    _CurrentTime += Time.deltaTime;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;

                    if (_CurrentTime >= _UsingTime)
                    {
                        ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.ItemD;
                        objCheck = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(1f, 1f, 0f), prefabCheck.transform.rotation) as GameObject;
                        objCheck.name = "check";
                        Destroy(objCheck, 3f);
                        Debug.Log("item D coletado");
                        _CurrentTime = 0f;
                        _isUsingObj = false;               
                        
                    }
                }
                else
                {
                    
                    objFoto = Instantiate(prefabFoto, _posicaoInstanciaFoto.transform.position, _posicaoInstanciaFoto.transform.rotation) as GameObject;
                    objFoto.name = "Sem Foto";
                    AnimFot.SetBool("chamar", true);
                    
                    Destroy(objFoto, 3f);
                }
            }
            
            
        // IDENTIFICACAO DE APROXIMACAO
            else if (_isUsingObj == false)
            {

                AnimFot.SetBool("chamar", false);
                gameObject.GetComponent<SpriteRenderer>().color = CorDeAproximacao;
            }
        }
        else
        {
            _isUsingObj = false;
            gameObject.GetComponent<SpriteRenderer>().color = minhaCor;
        }

        // verifica se esta segurando algo
        if (ItemAdquirido._ItemAdquirido.tipoItemColetado != ItemAdquirido.TipoItem.None)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
            }

            
        }
    }

    private void TempoDeFuncionamento()
    {
        // CALCULA O TEMPO DE USO DA IMPRESSORA
        if (_isUsingObj == false)
        {
            if (_canUse == true)
            {

                _CurrentTimeCanUse += Time.deltaTime;
                if (_CurrentTimeCanUse >= _canUseTime)
                {
                    
                    _canUse = false;
                    _CurrentTimeCanUse = 0f;
                    Debug.Log("nao pode usar");
                }
            }

        }
        //MOMENTO EM QUE A IMPRESSORA NAO PODE SER UTILIZADA
        if (_canUse == false)
        {
            Instantiatecount++;
            if (Instantiatecount == 1)
            {
                Obj = Instantiate(_InstReq, _posicaoInstancia.transform.position, _posicaoInstancia.rotation) as GameObject;
                Obj.name = "Requisito de Tinta";
                _isUsingObj = false;
                
            }
            
        }
    }
    
}
