using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Score 
{

    public string name;
    public float score;

    public Score(string name, float scor)
    {
        this.name = name;
        this.score = scor;
    }
   
}
