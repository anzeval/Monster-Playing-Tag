using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State {get; private set;}
    public int BestScore {get; private set;}

    public ArenaTimer arenaTimer {get; private set;}
    public PlayerLife playerLife {get; private set;}

    public event Action OnGameOver;
    public event Action OnGameWin;

     void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            BestScore = 0;
            State = GameState.Playing;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (arenaTimer != null)
        {
            arenaTimer.OnTimeEnded -= SetWinState;
        }

        if (playerLife != null)
        {
            playerLife.OnPlayerDied -= SetGameOverState;
        }
    }

    public void SetBestScore(int score)
    {
        BestScore = score;
    }

    public void LoadGameScene()
    {
        State = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetGameOverState()
    {
        State = GameState.GameOver;
        OnGameOver?.Invoke();
    }

    private void SetWinState()
    {
        State = GameState.Win;
        OnGameWin?.Invoke();
    }

    public void SetArenaTimer(ArenaTimer arena)
    {
        if (arenaTimer != null)
        {
            arenaTimer.OnTimeEnded -= SetWinState;
        }

        arenaTimer = arena;

        if (arenaTimer != null)
        {
            arenaTimer.OnTimeEnded += SetWinState;
        }
    }

    public void SetPlayerLife(PlayerLife player)
    {
        if (playerLife != null)
        {
            playerLife.OnPlayerDied -= SetGameOverState;
        }

        playerLife = player;

        if (playerLife != null)
        {
            playerLife.OnPlayerDied += SetGameOverState;
        }
    }
}