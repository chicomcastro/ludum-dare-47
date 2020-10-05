using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float score = 0;

    public float maxHitScore = 50f;
    public float timeLimit = 1f;

    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        score = 0f;
        UpdateScoreText(score);
    }

    public void CountScore(float hitTime)
    {
        float hitScore = (-(1 / Mathf.Pow(timeLimit, 2)) * Mathf.Pow(hitTime, 2) + 1) * maxHitScore;
        score += hitScore;
        UpdateScoreText(score);
    }

    private void UpdateScoreText(float score) {
        scoreText.text = "Score: " + ((int)Mathf.Round(score)).ToString();
    }
}
