using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Experiencia : MonoBehaviour
{
    public static Experiencia Experienc;
    [HideInInspector] public float _exp;
    private float valor;
    [SerializeField] TextMeshProUGUI num;
    private int  cont;

    private void Awake()
    {
        Experienc = this ;
        

    }

    private void Start()
    {
        cont = 0;
        gameObject.SetActive(true);
        _exp = 0;
        gameObject.GetComponent<Slider>().value = 0;
        
    }
    private void Update()
    {

        gameObject.GetComponent<Slider>().value = valor;

        string contString = string.Format("{0}", cont);
        num.text = contString;

        if (_exp >= 100)
        {
            cont++;
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
