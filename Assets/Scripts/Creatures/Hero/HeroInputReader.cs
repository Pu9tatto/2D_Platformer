using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    private HeroMovement _heroMovement;
    private HeroInputActions _inputActions;
    private HeroAnimations _heroAnimations;


    private void Awake()
    {
        _heroMovement = GetComponent<HeroMovement>();
        _inputActions = new HeroInputActions();
        _heroAnimations = GetComponent<HeroAnimations>();

    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Hero.Movement.performed += OnGetDirection;
        _inputActions.Hero.Movement.canceled += OnGetDirection;
        _inputActions.Hero.Interact.started += OnInteract;
        _inputActions.Hero.Attack.started += OnAttack;
        _inputActions.Hero.Throw.started += OnThrow;
        _inputActions.Hero.Throw.performed += OnHoldThrow;
        _inputActions.Hero.Throw.canceled += OnTryMultyThrow;

    }


    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Hero.Movement.performed -= OnGetDirection;
        _inputActions.Hero.Movement.canceled -= OnGetDirection;
        _inputActions.Hero.Interact.started -= OnInteract;
        _inputActions.Hero.Attack.started -= OnAttack;
        _inputActions.Hero.Throw.started -= OnThrow;
        _inputActions.Hero.Throw.performed -= OnHoldThrow;
        _inputActions.Hero.Throw.canceled -= OnTryMultyThrow;

    }


    private void OnGetDirection(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _heroMovement.SetDirection(direction);
        _heroAnimations.SetDirectionX(direction.x);
    }
    private void OnThrow(InputAction.CallbackContext obj)
    {
        Debug.Log("Press");
    }
    private void OnHoldThrow(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressing");
    }
    private void OnTryMultyThrow(InputAction.CallbackContext obj)
    {
        Debug.Log("Unpress");
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        _heroMovement.Interact();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        _heroAnimations.SetAttack();
    }

}
