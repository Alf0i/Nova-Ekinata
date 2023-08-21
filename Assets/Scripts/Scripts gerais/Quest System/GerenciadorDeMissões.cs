using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMissões : MonoBehaviour
{
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
        missões = gameObject.GetComponentsInChildren<DefiniçãoDeMissão>();
        missãoAtual = null;
        indexQuest = -1;
    }

    void Update()
    {

    }

    public void ComeçarMissão()
    {
        
        missãoAtual = missões[indexQuest];
        
        missãoAtual.PrepararMissão();
        
    }
}
