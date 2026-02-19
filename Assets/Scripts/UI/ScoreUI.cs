using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    void Start()
    {
        ScoreManager.instance.OnScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        ScoreManager.instance.OnScoreChanged -= UpdateScore;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
