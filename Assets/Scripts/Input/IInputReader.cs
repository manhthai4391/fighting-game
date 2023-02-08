using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public interface IInputReader
{
    UnityAction<Vector2> OnMoveEvent { get; set; }
    UnityAction OnLeftDashEvent { get; set; }
    UnityAction OnRightDashEvent { get; set; }
    UnityAction<string> OnAttackEvent { get; set; }

    void OnMove(InputAction.CallbackContext context);
    void OnLeftDash(InputAction.CallbackContext context);
    void OnRightDash(InputAction.CallbackContext context);
    void OnAttack(InputAction.CallbackContext context);
}
