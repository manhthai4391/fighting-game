using UnityEngine;

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

[CreateAssetMenu(menuName = "Attack Data", fileName = "New Attack")]
public class AttackData : ScriptableObject
{
    public string attackName;
    public HitboxType hitboxType;
    public AttackIntensity intensity;
    public AttackType attackType;
    public int damage;
    public float stun;
    public bool canBeBlocked;
    public bool isCritical;
    public int chipDamage;
}
