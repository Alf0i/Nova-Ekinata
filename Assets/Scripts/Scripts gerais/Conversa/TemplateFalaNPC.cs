using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TemplateFalaNPC : MonoBehaviour
{
    
    public string[] _linhas;
    private int index;
    public GameObject dialogo;
    public TextMeshProUGUI componenteDeTexto;

    private float velocidadeDeTexto = 0.1f;
    public bool _dialogoAtivo;
    public bool _podeFalar;

    private float distancia;
    public GameObject player;
    

    void Start()
    {
        _dialogoAtivo = false;
        _podeFalar = true;
        dialogo.SetActive(false);
        componenteDeTexto.text = string.Empty;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(gameObject.transform.position, player.transform.position);
        
        
        if (distancia <= 2.5)
        {
            _podeFalar = true;
        }
        else
        {
            _podeFalar = false;
        }


        if(_podeFalar = true && _dialogoAtivo == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<PlayerController>()._playerSpeed = 0f;
                ComeçarDialogo();
                
            }
        }
        else if (_podeFalar = true && _dialogoAtivo == true)
        {
            
            if (componenteDeTexto.text == _linhas[index])
            {   
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ProximaLinha();
                }
                else
                {
                    StopAllCoroutines();
                    componenteDeTexto.text = _linhas[index];
                   
                }
            }
        }
           
        
    }

    public void ComeçarDialogo()
    {
        _dialogoAtivo = true;
        dialogo.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());

        

    }

    IEnumerator TypeLine()
    {
        componenteDeTexto.text = " ";

        foreach (char c in _linhas[index].ToCharArray())
        {
            componenteDeTexto.text += c;
            yield return new WaitForSeconds(velocidadeDeTexto);
        }
    }

    void ProximaLinha()
    {
        if (index < _linhas.Length - 1)
        {
            index++;
            componenteDeTexto.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogo.SetActive(false);
            _dialogoAtivo = false;
            index = 0;
            FindObjectOfType<PlayerController>()._playerSpeed = 8f;
        }
    }

}
