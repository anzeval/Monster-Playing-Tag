using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private PlayerLife player;
    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameManager.instance.OnGameOver += DestroyEnemy;
        GameManager.instance.OnGameWin += DestroyEnemy;
    }

    void OnDisable()
    {
        GameManager.instance.OnGameOver -= DestroyEnemy;
        GameManager.instance.OnGameWin -= DestroyEnemy;
    }

    private void FixedUpdate()
    {
        if(!player) return;

        SetDestination(player.transform.position);
    }

    public void Init(PlayerLife playerLife)
    {
        player = playerLife;
    }

    private void SetDestination(Vector3 position)
    {
        Vector3 normilizedDirection = new Vector3( position.x - rb.position.x, position.y - rb.position.y, 0f).normalized;
        rb.linearVelocity = normilizedDirection * moveSpeed;
    } 

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
