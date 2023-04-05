using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    private Hero _hero;
    private HeroInputActions _inputActions;


    private void Awake()
    {
        _hero = GetComponent<Hero>();
        _inputActions = new HeroInputActions();

    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Hero.Movement.performed += OnHorizontalMovement;
        _inputActions.Hero.Movement.canceled += OnHorizontalMovement;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Hero.Movement.performed -= OnHorizontalMovement;
        _inputActions.Hero.Movement.canceled -= OnHorizontalMovement;
    }

    private void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
}
