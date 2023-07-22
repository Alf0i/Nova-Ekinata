using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objetivo 
{
    [TextArea(2, 4)]
    public string _descricao;
    public bool _objCompleto;

    public Transform _objetivoActT;
    public ObjetivoSM _objetivoAct;
    public Transform[] _objetos;

    public void Init()
    {
        _objetivoAct = _objetivoActT.GetComponent<ObjetivoSM>();

        _objetivoAct.PrepararObjetivo(_objetos);
    }

    public void ObjAtualiza()
    {
        if ( _objetivoAct.AtualizarObjetivo(_objetos) )
        {
            _objetivoAct.SairObjetivo(_objetos);
            _objCompleto = true;
        }
    }
}
