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
public class DefiniçãoObjetivo
{
    public string descrição;
    public Transform[] alvos;
    public AçãoDeObjetivo ação;

}

public class DefiniçãoDeMissão : MonoBehaviour
{

    public List<DefiniçãoObjetivo> objetivos;
    private List<GameObject> objetosDeMissão = new List<GameObject>();
    private int ObjetivoAtual;

    public bool completado;

    private GerenciadorDeMissões gerenciadorDeMissões;
    private bool missaoPreparada;
    private bool podeCompletar;
    private bool objetivoCompleto;
    void Start()
    {
        objetivoCompleto = false;
        podeCompletar =false;
        missaoPreparada = false;
        gerenciadorDeMissões = FindObjectOfType<GerenciadorDeMissões>();
    }

    void Update()
    {
        Debug.Log(ObjetivoAtual);
        if (Input.GetKeyDown(KeyCode.L) && gerenciadorDeMissões.missãoAtual != null)
        {
            CancelarMissão();
        }

        if (missaoPreparada)
        {
            /*foreach (DefiniçãoObjetivo objetivo in objetivos)
            {
                
                AtualizarMissão(objetivo.alvos);

                if (AtualizarMissão(objetivo.alvos) && podeCompletar)
                    objetivoCompleto = true;
                    CompletarObjetivo();
                    podeCompletar = false;
            }*/


            if (ObjetivoAtual < objetivos.Count)
            {

                AtualizarMissão(objetivos[ObjetivoAtual].alvos);

                if (AtualizarMissão(objetivos[ObjetivoAtual].alvos))
                {
                    podeCompletar = true;
                }

                if (podeCompletar)
                {
                    Debug.Log("pode completar");
                    objetivoCompleto = true;
                    CompletarObjetivo();
                    podeCompletar = false;
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
            foreach (Transform alvo in objetivo.alvos)
            {
                if (alvo != null)
                {
                    HandlerDeMissão handler = alvo.GetComponent<HandlerDeMissão>();
                    handler.SetarMissão(this, objetivo);
                    objetosDeMissão.Add(alvo.gameObject);
                    alvo.gameObject.SetActive(true);
                }
                
            }
        }

        missaoPreparada = true;
    }

    public bool AtualizarMissão(Transform[] objs)
    {
        bool result = false;

        foreach (var o in objs)
        {
            if (o == null)
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
        if (objetivoCompleto)
        {
            ObjetivoAtual++;

            if (ObjetivoAtual == objetivos.Count)
            {
                CompletarMissão();

            }
            objetivoCompleto = false;
        }
            
    }

    public void CompletarMissão()
    {
        gerenciadorDeMissões.missãoAtual = null;

        completado = true;
        gerenciadorDeMissões.indexQuest = 0;
    }
}
