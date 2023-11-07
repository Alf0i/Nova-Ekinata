using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaStart : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private float tempoAtual;
    [SerializeField] private Text text;
    private int var;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        tempoAtual = 0.1f;
        text.fontSize = 13;  
        var = 1;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtual -= Time.deltaTime;      
        
        if (tempoAtual <= 0)
        {
            
            text.fontSize += var;
            count++;
            if (count >= 1)
            {
                var = -var;
                count = 0;
            }
            if(var > 0)
            {
                tempoAtual = 0.2f;
            }
            else
            {
                tempoAtual = 0.8f;
            }   
        }
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            menu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
