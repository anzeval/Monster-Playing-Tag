using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] private Button restartButton;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        GameManager.instance.OnGameOver += ActivateCanvas;
        restartButton.onClick.AddListener(GameManager.instance.LoadGameScene);

        DeactivateCanvas();
    }

    void OnDisable()
    {
        GameManager.instance.OnGameOver -= ActivateCanvas;
    }

    private void ActivateCanvas()
    {
        panel.SetActive(true);
        scoreText.text = "Best Score: " + GameManager.instance.BestScore.ToString();
    }

    private void DeactivateCanvas()
    {
        panel.SetActive(false);
    }
}
