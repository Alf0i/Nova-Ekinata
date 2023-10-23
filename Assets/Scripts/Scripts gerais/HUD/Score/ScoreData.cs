using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ScoreData 
{
    public List<Score> sc;

    public ScoreData()
    {
        sc = new List<Score>();
    }
}
