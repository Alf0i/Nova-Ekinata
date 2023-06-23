using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvSprite : MonoBehaviour
{
    public static InvSprite _invSprite;

    public Sprite _sprNone;
    public Sprite _sprItemA;
    public Sprite _sprItemB;
    public Sprite _sprItemC;
    public Sprite _sprItemD;
    public Sprite _sprItemE;
    public Sprite _sprTinta;

    public Image sprRend;

    private void Awake()
    {
        _invSprite = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<Image>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
