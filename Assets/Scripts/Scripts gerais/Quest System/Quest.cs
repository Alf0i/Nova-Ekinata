using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string _nomeQuest;
    public bool complete;

    public int i;

    int MAX;
    public List<Objetivo> _objetivo;
    public bool _questIniciada;
    public bool _objetivoIniciado;
    public GameObject player;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        _questIniciada = false;
        _objetivoIniciado = false;


        /*if (_obj.Count <= 1)
        {
            if (_obj[i] != null)
            {
                _obj[i].Init();
            }
            else
            {
                _obj[i]._isComplete = true;
            }
        }
        else if (_obj.Count > 1)
        {
            foreach (var o in _obj)
            {
                if (o != null)
                {
                    o.Init();
                }
                else
                {
                    o._isComplete = true;
                }
            }
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (dist <= 2 && Input.GetKeyDown(KeyCode.Space))
        {
            _questIniciada = true;
        } 

        if (_questIniciada) {

            if (complete == true)
            {
                return;
            }

            else
            {

                if (_objetivo.Count <= 1)
                {

                    if (_objetivoIniciado == false)
                    { 
                        if (_objetivo[i] != null)
                        {
                            _objetivo[i].Init();
                            _objetivoIniciado = true;
                        }
                    }
                    else  
                    {
                        if (_objetivo[i] != null)
                        {

                            if (_objetivo[i]._objCompleto == true)
                            {
                                i++;
                                i = Mathf.Clamp(i, 0, _objetivo.Count - 1);
                                _objetivo[i].Init();
                                return;
                            }

                            _objetivo[i].ObjAtualiza();

                        }
                    }
                }

                else if (_objetivo.Count > 1)
                {

                    

                    if (_objetivoIniciado == false)
                    {
                        foreach (var o in _objetivo)
                        {
                            if(o != null)
                            {
                                o.Init();
                                _objetivoIniciado = true;
                            }
                            else
                            {
                                o._objCompleto = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var o in _objetivo)
                        {


                            if (o != null && o._objetivoAct != null)
                            {
                                o.ObjAtualiza();
                            
                            }
                            else
                            {
                                o._objCompleto = true;
                                
                            }
                        }
                    }

                    
                }

                if (ChecarTodosObjetivos())
                {
                    _questIniciada = false;
                    complete = true;
                }
            }
        }
        

    }

    bool ChecarTodosObjetivos()
    {
        bool result = false;

        foreach (var o in _objetivo)
        {
            if (o._objCompleto)
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }
        return result;
    }

}
