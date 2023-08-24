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

    [HideInInspector] public TemplateFalaNPC T;
    [HideInInspector] public GerenciadorDeMissões gm;
    [HideInInspector] public bool missaoPreparada;
    
    private bool podeCompletar;
    private bool objetivoCompleto;

    

    void Start()
    {
        objetivoCompleto = false;
        podeCompletar =false;
        missaoPreparada = false;
        gm = GerenciadorDeMissões.Gerencia;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && gm.missãoAtual != null)
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
                    
                    objetivoCompleto = true;
                    CompletarObjetivo();
                    podeCompletar = false;
                }
            }
        }


    }
    public string PegarNomeDeObjetivo()
    {
        return gameObject.name;
    }
    public string PegarDescriçãoDeObjetivo()
    {
        return objetivos[ObjetivoAtual].descrição;
    }

    public void PrepararMissão()
    {
        ObjetivoAtual = 0;
        /*foreach (GameObject objetoDeMissão in objetosDeMissão)
        {
            //Destroy(objetoDeMissão);
            objetoDeMissão.SetActive(true);
        }*/
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
       /* foreach (DefiniçãoObjetivo objetivo in objetivos)
        {
            foreach (Transform alvo in objetivo.alvos)
            {
                if (alvo != null)
                {
                    objetosDeMissão.Remove(alvo.gameObject);
                    alvo.gameObject.SetActive(false);
                }

            }
        }
        foreach (GameObject objetoDeMissão in objetosDeMissão)
        {
            Destroy(objetoDeMissão);
           
        }
        gm.indexQuest = -1;
        missaoPreparada = false;
        gm.missãoAtual = null;
        Debug.Log("Cancelou a missão" );*/
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
        gm.missãoAtual = null;
        Debug.Log("Completado");
        T.completado = true;
        gm.IndexQuest = -1;
    }
}
