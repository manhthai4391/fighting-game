using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
    private string _surfix;
    public UnityAction OnMoveLeftEvent { get; set; }
    public UnityAction OnMoveRightEvent { get; set; }
    public UnityAction OnStopMovingEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction<string> OnAttackEvent { get; set; }

    public string player1Surfix = "PLAYER_1_";

    public string player2Surfix = "PLAYER_2_";

    public string moveLeftActionName = "MOVE_LEFT";

    public string moveRightActionName = "MOVE_RIGHT";

    public string lightPunchActionName = "LIGHT_PUNCH";

    public string lightKickActionName = "LIGHT_KICK";

    public string mediumPunchActionName = "MEDIUM_PUNCH";

    public string mediumKickActionName = "MEDIUM_KICK";

    public string heavyPunchActionName = "HEAVY_PUNCH";

    public string heavyKickActionName = "HEAVY_KICK";

    public void Initialize(InputActionMap actionMap, int playerIndex)
    {
        _surfix = playerIndex == 0 ? player1Surfix : player2Surfix;

        InputAction moveleftAction = actionMap.FindAction(_surfix + moveLeftActionName);
        InputAction moveRightAction = actionMap.FindAction(_surfix + moveRightActionName);
        InputAction lightPunchAction = actionMap.FindAction(_surfix + lightPunchActionName);
        InputAction lightKickAction = actionMap.FindAction(_surfix + lightKickActionName);
        InputAction mediumPunchAction = actionMap.FindAction(_surfix + mediumPunchActionName);
        InputAction mediumKickAction = actionMap.FindAction(_surfix + mediumKickActionName);
        InputAction heavyPunchAction = actionMap.FindAction(_surfix + heavyPunchActionName);
        InputAction heavyKickAction = actionMap.FindAction(_surfix + heavyKickActionName);

        moveleftAction.performed += OnMoveLeft;
        moveRightAction.performed += OnMoveRight;

        moveleftAction.canceled += OnMoveLeft;
        moveRightAction.canceled += OnMoveRight;

        lightPunchAction.performed += OnAttack;
        lightKickAction.performed += OnAttack;
        mediumPunchAction.performed += OnAttack;
        mediumKickAction.performed += OnAttack;
        heavyPunchAction.performed += OnAttack;
        heavyKickAction.performed += OnAttack;
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                OnLeftDashEvent?.Invoke();
                return;
            }
            else if(context.phase == InputActionPhase.Canceled)
            {
                OnStopMovingEvent?.Invoke();
            }  
        }
        else
        {
            if(context.phase == InputActionPhase.Performed)
            {
                OnMoveLeftEvent?.Invoke();
                return;
            }
            else if(context.phase == InputActionPhase.Canceled)
            {
                OnStopMovingEvent?.Invoke();
            }  
        } 
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.interaction is MultiTapInteraction)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                OnRightDashEvent?.Invoke();
                return;
            }
            else if(context.phase == InputActionPhase.Canceled)
            {
                OnStopMovingEvent?.Invoke();
            } 
        }
        else
        {
            if(context.phase == InputActionPhase.Performed)
            {
                OnMoveRightEvent?.Invoke();
                return;
            }
            else if(context.phase == InputActionPhase.Canceled)
            {
                OnStopMovingEvent?.Invoke();
            } 
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackEvent?.Invoke(GetAttackName(context.action.name));
    }

    private string GetAttackName(string actionName)
    {
        return actionName.Remove(0, _surfix.Length);
    }
}
