using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaTinta : MonoBehaviour
{
    public ColetaTinta _ColetaTinta;

    private bool _isColected;
    private float distancia;
    private float distImp;
    public GameObject Tinta;
    public GameObject HUD;
    private bool _isNear;
    private bool _isNearImp;
    public GameObject imp;
    public GameObject Box;
    private float _CurrentTime;
    private float _ItemCooldown;
    private bool _podeEncherImp;


    // Start is called before the first frame update
    void Start()
    {
        _ColetaTinta = this;


        _ItemCooldown = 2f;
        _CurrentTime = 0f;
        _isColected = false;
        _isNear = false;
        _isNearImp = false;
        _podeEncherImp = false;
    }

    // Update is called once per frame
    void Update()
    {
        //DISTANCIA DA CAIXA

        if (distancia <= 2f)
        {
            _isNear = true;
        }
        else
        {
            _isNear = false;
        }

        //DISTANCIA DA IMPRESSORA

        if (distImp <= 2f)
        {
            _isNearImp = true;
        }
        else
        {
            _isNearImp = false;
        }

        // encher impressora

        if (ExecImpressora._ExecImpressora._canUse == false)
        {
            if (_isNear == false)
            {
                if (_isNearImp == true)
                {

                    if (Input.GetKey(KeyCode.F))
                    {

                        _podeEncherImp = true;
                    }
                    else
                    {
                        _podeEncherImp = false;
                    }
                }
            }
        }
        else
        {
            _podeEncherImp = false;
        }
    }

    private void FixedUpdate()
    {   
        distancia = Vector2.Distance(gameObject.transform.position, Box.transform.position);
        distImp = Vector2.Distance(gameObject.transform.position, imp.transform.position);

        


        //COLETA A TINTA 
        if (_isColected == false)
        {
            _CurrentTime += Time.deltaTime;
            if (_isNear == true)
            {
                if (_CurrentTime >= _ItemCooldown)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        _isColected = true;
                        ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.Tinta;
                        _CurrentTime = 0f;
                    }
                }  
            }
            
             
        }

        else 
        {
            _CurrentTime += Time.deltaTime;
            //APLICA A TINTA NA IMPRESSORA
            if (_podeEncherImp == true)
            {
                
                _isColected = false;
                _CurrentTime = 0;
                _podeEncherImp = false;
                Destroy(ExecImpressora._ExecImpressora.Obj);
                ExecImpressora._ExecImpressora._canUse = true;
                ExecImpressora._ExecImpressora.Instantiatecount = 0;
                ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                
            }
            
            //DEVOLVE A TINTA PARA A CAIXA
            if (_CurrentTime >= _ItemCooldown)
            {
                if (_isNear == true)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        
                        _isColected = false;
                        _CurrentTime = 0f;
                        ItemAdquirido._ItemAdquirido.tipoItemColetado = ItemAdquirido.TipoItem.None;
                    }
                }
            }

        }
    }
}
