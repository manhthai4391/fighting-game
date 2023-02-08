using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

public class InputReader : MonoBehaviour, IInputReader
{
    public UnityAction<Vector2> OnMoveEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction<string> OnAttackEvent { get; set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
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
        if (context.phase == InputActionPhase.Performed && context.interaction is MultiTapInteraction)
        {
            OnLeftDashEvent?.Invoke();
        }
    }

    public void OnRightDash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && context.interaction is MultiTapInteraction)
        {
            OnRightDashEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            OnAttackEvent?.Invoke(context.action.name);
        }
    }
}
