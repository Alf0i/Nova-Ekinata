using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoVideo : MonoBehaviour
{
    [SerializeField] private GameObject start;
    private float tempoAtual;
    private bool terminouTempo;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(false);
        tempoAtual = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!terminouTempo)
        {
            tempoAtual -= Time.deltaTime;
            if (tempoAtual < 0)
            {
                start.SetActive(true);
                terminouTempo = true;
            }
        }
        else
        {
            tempoAtual = 0;
            gameObject.SetActive(false);
        }
    }
}
