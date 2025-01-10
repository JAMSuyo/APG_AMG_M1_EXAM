using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public static int scoreCount;

    void Update()
    {
        Score.text = "Score: " + Mathf.Round(scoreCount);
    }

    private void IncreaseScore(int amount)
    {
        scoreCount += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (Score != null)
        {
            Score.text = "Score: " + Mathf.Round(scoreCount);
        }
    }
}
