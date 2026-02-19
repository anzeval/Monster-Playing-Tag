using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{   
    private InputAction move;
    private InputAction attack;

    public event Action<Vector2> OnMove;
    public event Action OnAttack;

    void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        move = input.actions["Move"];
        attack = input.actions["Attack"];
    }

    void OnEnable()
    {
        move.Enable();
        attack.Enable();
        
        move.performed += Move;
        move.canceled += Move;

        attack.performed += Attack;
    }

    void OnDisable()
    {
        move.performed -= Move;
        move.canceled -= Move;

        attack.performed -= Attack;

        move.Disable();
        attack.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void Attack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }
}
