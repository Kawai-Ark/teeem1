using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    int score = 0;
    public Text scoretext;

    void Start()
    {
        
    }

    public void AddScore()
    {
        score += 10;
    }

   public void TakeScore()
    {
        if (score > 0)
        {
            score -= 5;
        }
    }

    void Update()
    {
        scoretext.text = score.ToString();
    }
}
