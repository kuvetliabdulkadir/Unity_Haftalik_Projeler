using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    internal void IncreaseScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}