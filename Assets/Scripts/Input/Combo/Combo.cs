using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fighting Game/Combo", fileName = "New Combo")]
public class Combo : ScriptableObject
{
    public InputCombo[] inputCombos;
    public AttackData attackData;
}

public enum InputCombo : int
{
    FORWARD,
    BACKWARD,
    UP,
    DOWN,
    LIGHT_PUNCH,
    LIGHT_KICK,
    MEDIUM_PUNCH,
    MEDIUM_KICK,
    HEAVY_PUNCH,
    HEAVY_KICK
}