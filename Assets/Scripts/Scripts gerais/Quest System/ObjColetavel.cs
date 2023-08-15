using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColetavel : MonoBehaviour
{
    
    [SerializeField] bool coletado;

    // Start is called before the first frame update
    void Start()
    {
        coletado = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !coletado)
            {
                Destroy(this.gameObject);
                coletado = true;
            }
        }
        
    }
}
