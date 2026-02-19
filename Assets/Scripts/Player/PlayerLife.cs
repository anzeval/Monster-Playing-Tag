using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    public event Action OnPlayerDied;

    void Awake()
    {
        GameManager.instance.SetPlayerLife(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            ScoreManager.instance.ResetScore();
            OnPlayerDied?.Invoke();
        }
    }
}
