using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] ArenaTimer arenaTimer;
    [SerializeField] TMP_Text timeText;

    private void Start() 
    {
        arenaTimer.OnTimeChanged += UpdateTime;
    }

    void OnDisable()
    {
        arenaTimer.OnTimeChanged -= UpdateTime;
    }

    private void UpdateTime(float minutes, float seconds)
    {
        string minutesStr = minutes.ToString();
        string secondsStr = (seconds > 9)? seconds.ToString() : "0" + seconds.ToString();

        timeText.text = "Survival time: " + minutesStr + ":" + secondsStr;
    }
}
