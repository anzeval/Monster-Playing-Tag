using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveInput;

    void OnEnable()
    {
        playerInputController.OnMove += Move;
    }

    void OnDisable()
    {
        playerInputController.OnMove -= Move;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void Move(Vector2 direction)
    {
        moveInput = direction;
    }
}
