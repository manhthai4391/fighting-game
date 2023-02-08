using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData
{
    public Vector3 hitPoint;
    public AttackData attack;
    public HurtBoxPosition hurtBoxPosition;
    public bool wasBlocked;
    public bool wasParry;
    public Transform hurtBoxTransform;
}
