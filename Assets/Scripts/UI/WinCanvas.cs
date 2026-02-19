using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    
    [SerializeField] GameObject panel;
    [SerializeField] private Button restartButton;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        GameManager.instance.OnGameWin += ActivateCanvas;
        restartButton.onClick.AddListener(GameManager.instance.LoadGameScene);

        DeactivateCanvas();
    }

    void OnDisable()
    {
        GameManager.instance.OnGameWin -= ActivateCanvas;
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
