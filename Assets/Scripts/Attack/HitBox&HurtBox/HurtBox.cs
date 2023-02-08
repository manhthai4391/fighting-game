using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HurtBox : MonoBehaviour, IHurtBoxBase
{
    public UnityAction<HitData> onHitEvent = delegate { };
    public HurtBoxPosition hurtBoxType;

    public void TakeDamage(HitData hitData)
    {
        hitData.hurtBoxPosition = hurtBoxType;
        onHitEvent?.Invoke(hitData);
    }
}
