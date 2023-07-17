using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string _nomeQuest;
    public bool complete;

    public int i;

    int MAX;
    public List<Objetivo> _obj;
    public bool _questIniciada;
    public GameObject player;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        _questIniciada = false;



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

                if (_obj.Count <= 1)
                {


                    if (_obj[i] != null)
                    {

                        if (_obj[i]._isComplete == true)
                        {
                            i++;
                            i = Mathf.Clamp( i, 0, _obj.Count -1);
                            _obj[i].Init();
                            return;
                        }
                        else 
                        {
                            i = Mathf.Clamp(i, 0, _obj.Count - 1);
                            _obj[i].Init();
                            return;
                        }

                        

                    }
                
                }

                else if (_obj.Count > 1)
                {

                    i = 0;
                    foreach (var o in _obj)
                    {


                        if (o != null && o._objetivoAct != null)
                        {
                            if (i == 0)
                            {
                                o.Init();
                                i++;
                            }
                            else
                            {
                                o.ObjAtualiza();
                                i++;
                            }
                            
                        }
                        else
                        {
                            o._isComplete = true;
                            i = 0;
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

        foreach (var o in _obj)
        {
            if (o._isComplete)
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
