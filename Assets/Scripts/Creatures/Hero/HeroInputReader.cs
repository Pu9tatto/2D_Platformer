using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    private HeroMovement _heroMovement;
    private HeroInputActions _inputActions;
    private HeroAnimations _heroAnimations;
    private HeroThrow _heroThrow;
    private HeroActions _heroActions;

    private void Awake()
    {
        _inputActions = new HeroInputActions();
        _heroActions = GetComponent<HeroActions>();
        _heroMovement = GetComponent<HeroMovement>();
        _heroAnimations = GetComponent<HeroAnimations>();
        _heroThrow = GetComponent<HeroThrow>();

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
        _inputActions.Hero.UsePoison.started += OnUsePoision;
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
        _inputActions.Hero.UsePoison.started -= OnUsePoision;
    }


    private void OnGetDirection(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _heroMovement.SetDirection(direction);
        _heroAnimations.SetDirectionX(direction.x);
    }
    private void OnThrow(InputAction.CallbackContext obj)
    {
        _heroThrow.PressThrow();
    }
    private void OnHoldThrow(InputAction.CallbackContext obj)
    {
    }
    private void OnTryMultyThrow(InputAction.CallbackContext obj)
    {
        _heroAnimations.TryThrow();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        _heroActions.Interact();
    }

    private void OnUsePoision(InputAction.CallbackContext context)
    {
        _heroActions.DrinkPoision();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        _heroAnimations.TrySetAttack();
    }

}
