using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMissões : MonoBehaviour
{
    public DefiniçãoDeMissão[] missões;
    public DefiniçãoDeMissão missãoAtual;

    public int indexQuest;

    public static GerenciadorDeMissões Gerencia;

    void Awake()
    {
        Gerencia = this;
    }

    void Start()
    {
        missões = GetComponentsInChildren<DefiniçãoDeMissão>();
        missãoAtual = null;

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
