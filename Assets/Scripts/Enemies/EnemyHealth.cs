using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject explotionPrefab;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int scoreAmount = 100;
    private float lifeTimer = 0;

    void Update()
    {
        HandleLifeTime();
    }

    private void HandleLifeTime()
    {
        if(lifeTime > lifeTimer)
        {
            lifeTimer += Time.deltaTime;
        } 
        else
        {
            ScoreManager.instance.AddScore(scoreAmount);
            
            ExplosionHandler explosion = Instantiate(explotionPrefab, transform.position, Quaternion.identity).GetComponent<ExplosionHandler>();
            explosion.CauseExplosion();
            Destroy(gameObject);
        }
    }
}
