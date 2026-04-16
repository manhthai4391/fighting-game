using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
    [SerializeField]
    private float _doubleTapThreshold = 0.25f;
    private string _suffix;
    private float _lastLeftTapTime;
    private float _lastRightTapTime;

    public UnityAction OnMoveLeftEvent { get; set; }
    public UnityAction OnMoveRightEvent { get; set; }
    public UnityAction OnStopMovingEvent { get; set; }
    public UnityAction OnLeftDashEvent { get; set; }
    public UnityAction OnRightDashEvent { get; set; }
    public UnityAction<string> OnAttackEvent { get; set; }
    public string Player1Suffix = "PLAYER_1_";
    public string Player2Suffix = "PLAYER_2_";
    public string MoveLeftActionName = "MOVE_LEFT";
    public string MoveRightActionName = "MOVE_RIGHT";
    public string LightPunchActionName = "LIGHT_PUNCH";
    public string LightKickActionName = "LIGHT_KICK";
    public string MediumPunchActionName = "MEDIUM_PUNCH";
    public string MediumKickActionName = "MEDIUM_KICK";
    public string HeavyPunchActionName = "HEAVY_PUNCH";
    public string HeavyKickActionName = "HEAVY_KICK";

    public void Initialize(InputActionMap actionMap, int playerIndex)
    {
        _suffix = playerIndex == 0 ? Player1Suffix : Player2Suffix;

        InputAction moveleftAction = actionMap.FindAction(_suffix + MoveLeftActionName);
        InputAction moveRightAction = actionMap.FindAction(_suffix + MoveRightActionName);
        InputAction lightPunchAction = actionMap.FindAction(_suffix + LightPunchActionName);
        InputAction lightKickAction = actionMap.FindAction(_suffix + LightKickActionName);
        InputAction mediumPunchAction = actionMap.FindAction(_suffix + MediumPunchActionName);
        InputAction mediumKickAction = actionMap.FindAction(_suffix + MediumKickActionName);
        InputAction heavyPunchAction = actionMap.FindAction(_suffix + HeavyPunchActionName);
        InputAction heavyKickAction = actionMap.FindAction(_suffix + HeavyKickActionName);

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
        if(context.phase == InputActionPhase.Performed)
        {
            float currentTime = Time.time;
            if (currentTime - _lastLeftTapTime < _doubleTapThreshold)
            {
                OnLeftDashEvent?.Invoke();
                _lastLeftTapTime = currentTime;
                return;
            }
            _lastLeftTapTime = currentTime;
            OnMoveLeftEvent?.Invoke();
            return;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            OnStopMovingEvent?.Invoke();
        }  
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            float currentTime = Time.time;
            if (currentTime - _lastRightTapTime < _doubleTapThreshold)
            {
                OnRightDashEvent?.Invoke();
                _lastRightTapTime = currentTime;
                return;
            }
            _lastRightTapTime = currentTime;
            OnMoveRightEvent?.Invoke();
            return;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            OnStopMovingEvent?.Invoke();
        } 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackEvent?.Invoke(GetAttackName(context.action.name));
    }

    private string GetAttackName(string actionName)
    {
        return actionName.Remove(0, _suffix.Length);
    }
}
