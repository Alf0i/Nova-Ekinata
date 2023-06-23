using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostraSala : MonoBehaviour
{
    public GameObject _player;
    public bool _descobriu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _descobriu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_descobriu == true)
        {
            Destroy(gameObject);
        }

        Descoberta();
    }

    void Descoberta()
    {
        if (gameObject.GetComponent<BoxCollider2D>().IsTouching(_player.GetComponent<BoxCollider2D>()))
        {
            _descobriu = true;
        }
    }
}
