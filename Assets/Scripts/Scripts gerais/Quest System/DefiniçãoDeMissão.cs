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
public class RecompensaObjetivo
{
    public GameObject[] item;

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
    [SerializeField] DefiniçãoDeMissão[] preRequisitos;
    [HideInInspector] public EstadoMissao _est;
    public float recEXP;
    [HideInInspector] public Experiencia E;
    public List<RecompensaObjetivo> recompensas;
    public List<DefiniçãoObjetivo> objetivos;
    private List<GameObject> objetosDeMissão = new List<GameObject>();
    [HideInInspector] public int ObjetivoAtual;

    [HideInInspector] public GerenciadorDeMissões gm;
    [HideInInspector] public bool missaoPreparada;

    private bool podeCompletar;
    private bool objetivoCompleto;
    public bool completado;


    void Start()
    {
        
        completado = false;
        objetivoCompleto = false;
        podeCompletar = false;
        missaoPreparada = false;
        gm = GerenciadorDeMissões.Gerencia;
        E = Experiencia.Experienc;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && gm.missãoAtual != null)
        {
            CancelarMissão();
        }

        if (missaoPreparada)
        {
           
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
                    if(alvo.gameObject.activeSelf == true)
                    {
                        Debug.Log("Ta funfando");
                    }    
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
        Debug.Log("Completado");
        completado = true;
        ColetarRecompensa();
        missaoPreparada = false;
        Destroy(gameObject);
    }

    public void ColetarRecompensa()
    {
        foreach(RecompensaObjetivo o in recompensas)
        {
            //adicionar cada game object em uma lista de items do inventario
        }
        E.AdicionarExp(recEXP);
    }

    public bool RequisitosCompletos()
    {
        bool result = true;
        
        if (preRequisitos != null)
        {
            foreach (var o in preRequisitos)
            {
                if (o.completado)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
        }        
               
        return result;
    }
}
