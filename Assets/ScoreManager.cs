using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float score = 0;

    public float maxHitScore = 50f;
    public float timeLimit = 0.5f;

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
    }

    public void CountScore(float hitTime)
    {
        float hitScore = (-(1 / Mathf.Pow(timeLimit, 2)) * Mathf.Pow(hitTime, 2) + 1) * maxHitScore;
        score += hitScore;
    }
}
