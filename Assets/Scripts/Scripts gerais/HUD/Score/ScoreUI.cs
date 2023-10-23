using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI scUI;
    public RowUI row;
    public ScoreManager scoreM;
    public GameObject HighScore;

    private void Awake()
    {
        scUI = this;
    }
    void Start()
    {

        HighScore.SetActive(false);

    }

    public void MostrarScore(string nome, float ponto)
    {
        HighScore.SetActive(true);
        scoreM.AddScore(new Score(nome, ponto));
        int val = 1;
        var scores = scoreM.sd.sc;
        for (int i = 0; i < scores.Count; i++)
        {
            for(int j = i + 1; j< scores.Count; j++)
            {
                if (scores[j].score > scores[i].score)
                {
                    Score tmp = scores[i];
                    scores[i] = scores[j];
                    scores[j] = tmp;
                }
            }
            
        }
        foreach(Score sc in scores)
        {
            
            var rowVar = Instantiate(row, transform).GetComponent<RowUI>();
            rowVar.rank.text = val.ToString();
            val++;
            rowVar.nam.text = sc.name;
            rowVar.score.text = sc.score.ToString();
            
        }
    }

    public void MostrarScoreSemPontos()
    {
        HighScore.SetActive(true);


        int val = 1;
        var scores = scoreM.sd.sc;
        for (int i = 0; i < scores.Count; i++)
        {
            for (int j = i + 1; j < scores.Count; j++)
            {
                if (scores[j].score > scores[i].score)
                {
                    Score tmp = scores[i];
                    scores[i] = scores[j];
                    scores[j] = tmp;
                }
            }

        }
        foreach (Score sc in scores)
        {

            var rowVar = Instantiate(row, transform).GetComponent<RowUI>();
            rowVar.rank.text = val.ToString();
            val++;
            rowVar.nam.text = sc.name;
            rowVar.score.text = sc.score.ToString();

        }
    }

    public void Remover()
    {
        scoreM.RemoveScore();
    }
}
