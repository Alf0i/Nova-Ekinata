using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static UnityEditor.PlayerSettings;

public class MenuScript : MonoBehaviour
{
    private Paginas pag;
    public GameObject menu;
    public GameObject hud;
    public bool menuAberto;
    private IniciaJogo ij;
    [SerializeField]private GameObject menuTela;
    private InfoPanelScore info;
    // Start is called before the first frame update
    void Start()
    {
        pag = gameObject.GetComponent<Paginas>();
        menu.SetActive(false);
        menuAberto = false;
        ij = IniciaJogo.Ij;
        info = InfoPanelScore.ips;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!pag.aberto && ij.comecou && !pag.iniciado)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !menuAberto)
            {
                menu.SetActive(true);
                menuAberto = true;
                GameControl._PauseGeral = true;
                Time.timeScale = 0f;
                hud.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && menuAberto && menuTela.activeInHierarchy)
            {
                if (info != null)
                {
                    menu.SetActive(false);
                    menuAberto = false;
                    GameControl._PauseGeral = false;
                    hud.SetActive(true);
                    if (!info.jogoTerminado)
                    {
                        Time.timeScale = 1f;
                    }
                }
                else
                {
                    menu.SetActive(false);
                    menuAberto = false;
                    GameControl._PauseGeral = false;
                    hud.SetActive(true);
                    Time.timeScale = 1f;
                }
                    
                

            }
        }
        
    }
}
