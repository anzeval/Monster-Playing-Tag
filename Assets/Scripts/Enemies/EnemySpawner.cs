using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PlayerLife player;
    [SerializeField] private ArenaTimer arenaTimer;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private float spawnRate = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (GameManager.instance.State == GameState.Playing)
        {
            GameObject enemyPrefab = SelectEnemy();
            Vector3 position = SelectPosition();
            EnemyMovement enemy = Instantiate(enemyPrefab, position, Quaternion.identity, transform).GetComponent<EnemyMovement>();

            enemy.Init(player);
            yield return new WaitForSecondsRealtime(spawnRate);
        }
    }

    private GameObject SelectEnemy()
    {
        return (enemyPrefabs.Length == 0)? null : enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
    }

    private Vector3 SelectPosition()
    {
        return (spawnPoints.Length == 0)? new Vector3() : spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
