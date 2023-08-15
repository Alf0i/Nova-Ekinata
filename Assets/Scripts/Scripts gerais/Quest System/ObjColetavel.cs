using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColetavel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
               
            }
        }
        
    }
}
