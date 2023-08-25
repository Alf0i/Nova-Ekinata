using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objdefala : MonoBehaviour
{
    private float dist;
    [SerializeField] GameObject pai;
    private TemplateFalaNPC t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponentInParent<TemplateFalaNPC>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(pai.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (dist <= 2)
        {
            if (Input.GetKeyUp(KeyCode.Space) && t.falar.dialogoTerminado)
            {
                Destroy(gameObject);
                t.falar.dialogoTerminado = false;
            }
        }
    }
}
