using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int totalScore = 0;
    public event Action<int> OnScoreChanged;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void TrySetBestScore()
    {
        if(totalScore <= GameManager.instance.BestScore) return;
        
        GameManager.instance.SetBestScore(totalScore);
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        OnScoreChanged?.Invoke(totalScore);
        TrySetBestScore();
    }

    public void ResetScore()
    {
        totalScore = 0;
        OnScoreChanged?.Invoke(totalScore);
    }
}
