using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
    public InputActionAsset inputActionAsset;

    public UnityAction<Vector2> OnMoveEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction<string> OnAttackEvent { get; set; }

    public void Initialize(InputActionAsset inputActions)
    {
        inputActionAsset = inputActions;
        inputActionAsset.Enable();
        InputActionMap actionMap = inputActionAsset.FindActionMap("Gameplay");
        InputAction moveAction = actionMap.FindAction("MOVE");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        actionMap.FindAction("RIGHT_DASH").performed += OnRightDash;
        actionMap.FindAction("LEFT_DASH").performed += OnLeftDash;
        actionMap.FindAction("LIGHT_PUNCH").performed += OnAttack;
        actionMap.FindAction("LIGHT_KICK").performed += OnAttack;
        actionMap.FindAction("MEDIUM_PUNCH").performed += OnAttack;
        actionMap.FindAction("MEDIUM_KICK").performed += OnAttack;
        actionMap.FindAction("HEAVY_PUNCH").performed += OnAttack;
        actionMap.FindAction("HEAVY_KICK").performed += OnAttack;
    }

    private void Start()
    {
        Initialize(inputActionAsset);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            OnMoveEvent?.Invoke(Vector2.zero);
        }
    }

    public void OnLeftDash(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction)
        {
            OnLeftDashEvent?.Invoke();
        }
    }

    public void OnRightDash(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction)
        {
            OnRightDashEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackEvent?.Invoke(context.action.name);
    }

    private void OnDestroy()
    {
        inputActionAsset.Disable();
        inputActionAsset = null;
    }
}
