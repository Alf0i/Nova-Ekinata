using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerDeMissão : MonoBehaviour
{

    private DefiniçãoDeMissão missão;
    private DefiniçãoObjetivo objetivo;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetarMissão(DefiniçãoDeMissão m, DefiniçãoObjetivo o)
    {
        missão = m;
        objetivo = o;
    }

    public void CompletarObjetivo()
    {
        switch(objetivo.ação)
        {
            case AçãoDeObjetivo.COLETAR:
                missão.CompletarObjetivo();
                break;

            case AçãoDeObjetivo.USAR:
                missão.CompletarObjetivo();
                break; 
        }
    }

    // .SendMessage("CompletarObjetivo", SendMessageOptions.DontRequireReceiver);
}
