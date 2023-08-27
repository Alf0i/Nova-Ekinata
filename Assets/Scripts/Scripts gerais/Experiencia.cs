using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Experiencia : MonoBehaviour
{
    public static Experiencia Experienc;
    [HideInInspector] public float _exp;
    private float valor;


    private void Awake()
    {
        Experienc = this ;
        

    }

    private void Start()
    {
        gameObject.SetActive(true);
        _exp = 0;
        gameObject.GetComponent<Slider>().value = 0;
    }
    private void Update()
    {

        gameObject.GetComponent<Slider>().value = valor;

        if (_exp >= 100)
        {
            _exp =_exp - 100;
            valor = valor - 1;
        }
    }

    public void AdicionarExp(float exp)
    {
        _exp += exp;
        valor += exp / 100;
        
    }


}
