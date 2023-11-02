using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{

    public ScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.sc.OrderBy(x=>x.score);
    }

    public void AddScore(Score score)
    {
        sd.sc.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

    public void RemoveScore()
    {
        sd.sc.Clear();
    }
}
