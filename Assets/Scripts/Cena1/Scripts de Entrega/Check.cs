using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject obj;
    public GameObject prefabCheck;
    public float dist;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ExecImpressora._ExecImpressora._isNear == true)
        {

            if (ExecImpressora._ExecImpressora._isUsingObj == true)
            {
                if (ItemAdquirido._ItemAdquirido.tipoItemColetado == ItemAdquirido.TipoItem.ItemA)
                {


                    if (ExecImpressora._ExecImpressora._CurrentTime >= ExecImpressora._ExecImpressora._UsingTime)
                    {

                        obj = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(dist, dist, 0f), prefabCheck.transform.rotation) as GameObject;

                        obj.name = "check";
                        Destroy(obj, 3f);
                    }
                }
            }
        }
        else if (ExecAtividade._ExecAtividade._CurrentTime >= ExecAtividade._ExecAtividade._UsingTime)
        {


            if (gameObject == GameObject.Find("Camera fotografica"))
            {

                obj = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(dist, dist, 0f), gameObject.transform.rotation) as GameObject;

                obj.name = "check";
                Destroy(obj, 3f);
            }

            else if (gameObject == GameObject.Find("Assinatura"))
            {
                obj = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(dist, dist, 0f), gameObject.transform.rotation) as GameObject;

                obj.name = "check";
                Destroy(obj, 3f);
            }

            else if (gameObject == GameObject.Find("Digital"))
            {
                obj = Instantiate(prefabCheck, gameObject.transform.position + new Vector3(dist, dist, 0f), gameObject.transform.rotation) as GameObject;

                obj.name = "check";
                Destroy(obj, 3f);
            }
        }
        
    }
}
