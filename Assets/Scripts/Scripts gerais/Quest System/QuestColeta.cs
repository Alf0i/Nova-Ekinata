using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestColeta : MonoBehaviour, ObjetivoSM
{
    public bool AtualizarObjetivo(Transform[] objs)
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

    public void PrepararObjetivo(Transform[] objs)
    {
        foreach (var o in objs)
        {
            o.gameObject.SetActive(true);
        }
    }

    public void SairObjetivo(Transform[] objs)
    {
        
    }

    
}
