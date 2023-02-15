using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ComboInputReader : MonoBehaviour, IInputReader
{
    public UnityAction<Vector2> OnMoveEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction<string> OnAttackEvent { get; set; }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
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
}
