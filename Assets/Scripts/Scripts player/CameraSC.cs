using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSC : MonoBehaviour
{
    public GameObject Obj_Cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Obj_Cam.transform.position;
        
    }
}
