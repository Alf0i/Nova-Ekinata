using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelScore : MonoBehaviour
{
    public static InfoPanelScore ips;
    [HideInInspector]public string n;
    public bool telafechada;
    private void Awake()
    {
        ips = this;
    }
    void Start()
    {
        gameObject.SetActive(false);
        telafechada = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MostrarTelaPlayer()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
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
