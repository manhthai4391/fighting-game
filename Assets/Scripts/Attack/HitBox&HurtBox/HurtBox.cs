using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class HurtBox : MonoBehaviour, IHurtBoxBase
{
    [FormerlySerializedAs("onHitEvent")]
    public UnityAction<HitData> OnHitEvent = delegate { };
    [FormerlySerializedAs("hurtBoxType")]
    public HurtBoxPosition HurtBoxType;

    public void TakeDamage(HitData hitData)
    {
        hitData.HurtBoxPosition = HurtBoxType;
        OnHitEvent?.Invoke(hitData);
    }
}
