using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColetavel : MonoBehaviour
{
    private float dist;
    private GameObject player;
    [SerializeField] float distancia;
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if(dist <= distancia)
        {

            //Local para adcionar uma sprite de PRESSIONAR F.

            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);

            }
        }
    }
    
}
