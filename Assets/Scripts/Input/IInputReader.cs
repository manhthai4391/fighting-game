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
    UnityAction OnLightPunchEvent { get; set; }
    UnityAction OnMediumPunchEvent { get; set; }
    UnityAction OnHeavyPunchEvent { get; set; }
    UnityAction OnLightKickEvent { get; set; }
    UnityAction OnMediumKickEvent { get; set; }
    UnityAction OnHeavyKickEvent { get; set; }

    void OnMove(InputAction.CallbackContext context);
    void OnLeftDash(InputAction.CallbackContext context);
    void OnRightDash(InputAction.CallbackContext context);
    void OnLightPunch(InputAction.CallbackContext context);
    void OnMediumPunch(InputAction.CallbackContext context);
    void OnHeavyPunch(InputAction.CallbackContext context);
    void OnLightKick(InputAction.CallbackContext context);
    void OnMediumKick(InputAction.CallbackContext context);
    void OnHeavyKick(InputAction.CallbackContext context);
}
