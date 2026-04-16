using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HitData
{
    [FormerlySerializedAs("hitPoint")]
    public Vector3 HitPoint;
    [FormerlySerializedAs("attack")]
    public AttackData Attack;
    [FormerlySerializedAs("hurtBoxPosition")]
    public HurtBoxPosition HurtBoxPosition;
    [FormerlySerializedAs("hurtBoxTransform")]
    public Transform HurtBoxTransform;
}
