using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

public class InputReader : MonoBehaviour, IInputReader
{
    public UnityAction<Vector2> OnMoveEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction OnLightPunchEvent { get; set; }
    public UnityAction OnMediumPunchEvent { get; set; }
    public UnityAction OnHeavyPunchEvent { get; set; }
    public UnityAction OnLightKickEvent { get; set; }
    public UnityAction OnMediumKickEvent { get; set; }
    public UnityAction OnHeavyKickEvent { get; set; }

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

    public void OnLightPunch(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            OnLightPunchEvent?.Invoke();
        }
    }

    public void OnMediumPunch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnMediumPunchEvent?.Invoke();
        }
    }

    public void OnHeavyPunch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnHeavyPunchEvent?.Invoke();
        }
    }

    public void OnLightKick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnLightKickEvent?.Invoke();
        }
    }

    public void OnMediumKick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnMediumKickEvent?.Invoke();
        }
    }

    public void OnHeavyKick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnHeavyKickEvent?.Invoke();
        }
    }
}
