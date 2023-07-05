using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TemplateFalaNPC : MonoBehaviour
{
    [SerializeField] Dialogo falar;

    [TextArea(5, 8)]

    [SerializeField] string[] pages;

    [SerializeField] GameObject player;

    private float dist;
    private bool _podeFalar;
    // Start is called before the first frame update
    void Start()
    {
        _podeFalar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _podeFalar == true)
        {

            falar.AbrirDialogo(pages);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _podeFalar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _podeFalar = false;
        }
    }

}