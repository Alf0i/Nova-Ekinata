using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class GameControl
{
    public static bool _PauseGeral;
}

public class IniciaJogo : MonoBehaviour
{
    public static IniciaJogo Ij;
    public TextMeshProUGUI Text;
    private float count;
    //private float currentTime;
    private void Awake()
    {
        Ij=this;
    }

    private void Start()
    {
        count = 6;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        count -= Time.deltaTime;
        
        
        Text.text = string.Format("{0}\n", (int)count);
        if (count <= 1)
        {
            gameObject.SetActive(false);
            GameControl._PauseGeral = false;
        }
        
    }

}
