using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColetavel : MonoBehaviour
{
    private float dist;
    private GameObject player;
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if(dist <= 1)
        {

            //Local para adcionar uma sprite de PRESSIONAR F.

            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);

            }
        }
    }
    
}
