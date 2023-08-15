using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AçãoDeObjetivo
{
    COLETAR,
    USAR,
    IR
}

[System.Serializable]
public class DefiniçãoDeObjetoDeObjetivo
{
    public GameObject objectPrefab;
    public Vector3 spawnPosition;
}

[System.Serializable]
public class DefiniçãoObjetivo
{
    public string descrição;
    public List<DefiniçãoDeObjetoDeObjetivo> alvos;
    public AçãoDeObjetivo ação;

}

public class DefiniçãoDeMissão : MonoBehaviour
{

    public List<DefiniçãoObjetivo> objetivos;
    private List<GameObject> objetosDeMissão = new List<GameObject>();
    private int ObjetivoAtual;

    public bool completado;

    private GerenciadorDeMissões gerenciadorDeMissões;
    private int count;
    private bool missaoPreparada;
    void Start()
    {
        missaoPreparada = false;
        count = 0;
        gerenciadorDeMissões = FindObjectOfType<GerenciadorDeMissões>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && gerenciadorDeMissões.missãoAtual != null)
        {
            CancelarMissão();
        }
        if (missaoPreparada)
        {
            foreach (DefiniçãoObjetivo objetivo in objetivos)
            {
                foreach (DefiniçãoDeObjetoDeObjetivo alvo in objetivo.alvos)
                {
                    if (alvo.objectPrefab = null)
                    {
                        count++;
                    }

                }
                if (count >= objetivo.alvos.Count)
                {
                    CompletarObjetivo();
                    count = 0;
                }
            }
        }
        
       
    }

    public string PegarDescriçãoDeObjetivo()
    {
        return objetivos[ObjetivoAtual].descrição;
    }

    public void PrepararMissão()
    {
        ObjetivoAtual = 0;

        foreach (DefiniçãoObjetivo objetivo in objetivos)
        {
            foreach (DefiniçãoDeObjetoDeObjetivo alvo in objetivo.alvos)
            {
                if(alvo.objectPrefab != null)
                {
                    GameObject objetoDeMissão = Instantiate(alvo.objectPrefab, alvo.spawnPosition, transform.rotation);
                    HandlerDeMissão handler = objetoDeMissão.AddComponent<HandlerDeMissão>();
                    BoxCollider2D box = objetoDeMissão.AddComponent<BoxCollider2D>();
                    box.isTrigger = true;
                    handler.SetarMissão(this, objetivo);
                    objetosDeMissão.Add(objetoDeMissão);
                }

            }
        }
        missaoPreparada = true;
    }

    public void CancelarMissão()
    {
        foreach (GameObject objetoDeMissão in objetosDeMissão)
        {
            Destroy(objetoDeMissão);
        }

        gerenciadorDeMissões.missãoAtual = null;
        Debug.Log("Cancelo a missão" );
    }

    public void CompletarObjetivo()
    {
        ObjetivoAtual++;

        if(ObjetivoAtual == objetivos.Count)
        {
            CompletarMissão();
        }
    }

    public void CompletarMissão()
    {
        gerenciadorDeMissões.missãoAtual = null;

        completado = true;
    }
}
