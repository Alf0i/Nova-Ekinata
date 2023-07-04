using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TemplateFalaNPC : MonoBehaviour
{
    public static TemplateFalaNPC TemplFala;
    public string[] linhas;
    public TextMeshProUGUI componenteDeTexto;
    private float distancia;
    public GameObject player;
    

    private void Awake()
    {
        TemplFala = this;
    }
    void Start()
    {
        componenteDeTexto.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (distancia <= 2.5)
        {
            if (Dialogo.dialog._dialogoAtivo == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Dialogo.dialog.ComeçarDialogo();

                }
            }
        }





        distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);
    }
}
