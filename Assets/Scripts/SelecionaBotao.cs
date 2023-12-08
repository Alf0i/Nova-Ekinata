using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelecionaBotao : MonoBehaviour
{
    public Button primaryButton;
    [SerializeField] private GameObject menuCredito;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject menu;
    [SerializeField] private MenuScript ajuda;
    
    // Start is called before the first frame update
    void Start()
    {
        primaryButton.Select();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComecarJogo()
    {
        SceneManager.LoadScene("SalaDeEspera");
    }

    public void ContinuarJogo()
    {
        ajuda.interruptorMenu = true;
        
    }

    public void MenuControles()
    {
        menuControles.SetActive(true);
        menuControles.GetComponent<SelecionaBotao>().primaryButton.Select();
        gameObject.SetActive(false);
    }

    

    public void MenuCreditos()
    {
        menuCredito.SetActive(true);
        menuCredito.GetComponent<SelecionaBotao>().primaryButton.Select();
        gameObject.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
