using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public interface IInputReader
{
    UnityAction OnMoveLeftEvent { get; set; }
    UnityAction OnMoveRightEvent { get; set; }
    UnityAction OnStopMovingEvent { get; set; }
    UnityAction OnLeftDashEvent { get; set; }
    UnityAction OnRightDashEvent { get; set; }
    UnityAction<string> OnAttackEvent { get; set; }

    void Initialize(InputActionMap actionMap, int playerIndex);
    void OnMoveLeft(InputAction.CallbackContext context);
    void OnMoveRight(InputAction.CallbackContext context);
    void OnAttack(InputAction.CallbackContext context);
}
