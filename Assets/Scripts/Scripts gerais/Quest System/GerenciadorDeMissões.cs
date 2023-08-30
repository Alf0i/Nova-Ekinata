using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMissões : MonoBehaviour
{

    //[HideInInspector] public EstadoMissao _est;
    public DefiniçãoDeMissão[] missões;
    public DefiniçãoDeMissão missãoAtual;

    public int indexQuest;
    public int IndexQuest { get => indexQuest; set => indexQuest = value; }

    public static GerenciadorDeMissões Gerencia;

    void Awake()
    {
        Gerencia = this;
    }

    void Start()
    {
        //missãoAtual._est = EstadoMissao.REQUERIMENTOS_A_FAZER;
        missões = gameObject.GetComponentsInChildren<DefiniçãoDeMissão>();
        missãoAtual = null;
        indexQuest = -1;
    }

    void Update()
    {
       /* if (missãoAtual.RequisitosCompletos(missões))
        {
            missãoAtual._est = EstadoMissao.PODE_INICIAR;
        }*/
    }

    public void ComeçarMissão()
    {
        
        missãoAtual.PrepararMissão();
        //missãoAtual._est = EstadoMissao.EM_PROGRESSO;
    }

    /*public bool Completo()
    {
        bool result;
        if (missãoAtual.completado)
        {
            result = true;
            missãoAtual._est = EstadoMissao.FINALIZADA;
        }
        else
        {
            result = false;
        }
        return result;
    }*/
   
   
}
