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
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Hero.Movement.performed -= OnGetDirection;
        _inputActions.Hero.Movement.canceled -= OnGetDirection;
        _inputActions.Hero.Interact.started -= OnInteract;
    }

    private void OnGetDirection(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _heroMovement.SetDirection(direction);
        _heroAnimations.SetDirectionX(direction.x);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        _heroMovement.Interact();
    }
}
