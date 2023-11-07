using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelScore : MonoBehaviour
{
    public static InfoPanelScore ips;
    [HideInInspector]public string n;
    public bool telafechada;
    public bool jogoTerminado;
    private void Awake()
    {
        ips = this;
    }
    void Start()
    {
        gameObject.SetActive(false);
        telafechada = false;
        jogoTerminado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MostrarTelaPlayer()
    {
        gameObject.SetActive(true);
        jogoTerminado = true;
        Time.timeScale = 0f;
        GameControl._PauseGeral = false;
    }

    public void FecharTelaPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            telafechada = true;
            gameObject.SetActive(false);
        }
    }

    public void ReadStringInput(string s)
    {
        n = s;
    }
}
