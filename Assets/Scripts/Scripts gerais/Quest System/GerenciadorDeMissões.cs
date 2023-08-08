using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMissões : MonoBehaviour
{
    public DefiniçãoDeMissão[] missões;
    public DefiniçãoDeMissão missãoAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        missões = GetComponentsInChildren<DefiniçãoDeMissão>();
        ComeçarMissão();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComeçarMissão()
    {
        missãoAtual = missões[1];
        missãoAtual.PrepararMissão();
    }
}
