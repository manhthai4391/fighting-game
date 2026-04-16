using UnityEngine;
using UnityEngine.Serialization;

public enum HitboxType
{
    NORMAL_ATTACK,
    PROJECTILE_ATTACK,
    THROW_ATTACK,
    PROXIMITY_HITBOX,
}

public enum AttackIntensity
{
    LIGHT,
    MEDIUM,
    HEAVY
}

public enum AttackType
{
    PUNCH,
    KICK
}

[CreateAssetMenu(menuName = "Fighting Game/Attack Data", fileName = "New Attack")]
public class AttackData : ScriptableObject
{
    [FormerlySerializedAs("attackName")]
    public string AttackName;
    [FormerlySerializedAs("hitboxType")]
    public HitboxType HitboxType;
    [FormerlySerializedAs("intensity")]
    public AttackIntensity Intensity;
    [FormerlySerializedAs("attackType")]
    public AttackType AttackType;
    [FormerlySerializedAs("damage")]
    public int Damage;
    [FormerlySerializedAs("stun")]
    public float Stun;
    [FormerlySerializedAs("canBeBlocked")]
    public bool CanBeBlocked;
    [FormerlySerializedAs("isCritical")]
    public bool IsCritical;
    [FormerlySerializedAs("chipDamage")]
    public int ChipDamage;
}
