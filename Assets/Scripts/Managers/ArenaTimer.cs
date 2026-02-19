using System;
using UnityEngine;

public class ArenaTimer : MonoBehaviour
{
    [SerializeField] private float roundDurationMinutes = 3f;
    private float timer;
    private float secondsInRound;

    private const float SECONDS_PER_MINUTE = 60f;

    public event Action<float,float> OnTimeChanged;
    public event Action OnTimeEnded;

    void Awake()
    {
        GameManager.instance.SetArenaTimer(this);
    }

    private void Start()
    {
        secondsInRound = roundDurationMinutes * SECONDS_PER_MINUTE;
        timer = secondsInRound;
    }

    private void Update()
    {
        if(timer  > 0 && GameManager.instance.State == GameState.Playing)
        {
            UpdateTime();
        } 
        else
        {
            ScoreManager.instance.ResetScore();
            OnTimeEnded?.Invoke();
        }
    }

    private void UpdateTime()
    {
        timer -= Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(timer);
        OnTimeChanged?.Invoke(time.Minutes, time.Seconds);
    }
}
