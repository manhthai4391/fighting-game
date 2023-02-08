using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HurtBoxPosition
{
    LOW,
    MIDDLE,
    HIGH
}
public interface IHurtBoxBase 
{
    void TakeDamage(HitData hitData);
}
