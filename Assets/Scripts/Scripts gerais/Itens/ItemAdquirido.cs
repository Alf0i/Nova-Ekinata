using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdquirido : MonoBehaviour
{
    public static ItemAdquirido _ItemAdquirido;
    public enum TipoItem 
    {
        None,
        ItemA,
        ItemB,
        ItemC,
        ItemD,
        ItemPasta,
        Tinta
    }

    public bool itemColetado;

    public TipoItem tipoItemColetado;

    public TipoItem tipoItemEntregue;

    private void Awake()
    {
        _ItemAdquirido = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemColetado = false;
        tipoItemColetado = TipoItem.None;
    }

    // Update is called once per frame
    void Update()
    {
        Organizacao();
    }
    
    public void Organizacao()
    {
        if(tipoItemColetado == TipoItem.None)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprNone;
            itemColetado = false;
        }
        
        else if (tipoItemColetado == TipoItem.ItemA)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprItemA;
            itemColetado = true;
        }
        
        else if (tipoItemColetado == TipoItem.ItemB)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprItemB;
            itemColetado = true;
        }
        
        else if (tipoItemColetado == TipoItem.ItemC)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprItemC;
            itemColetado = true;
        }
       
        else if (tipoItemColetado == TipoItem.ItemD)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprItemD;
            itemColetado = true;
        }

        else if (tipoItemColetado == TipoItem.ItemPasta)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprItemE;
            itemColetado = true;
        }
       
        else if (tipoItemColetado == TipoItem.Tinta)
        {
            InvSprite._invSprite.sprRend.sprite = InvSprite._invSprite._sprTinta;
            itemColetado = true;
        }
    }

}
