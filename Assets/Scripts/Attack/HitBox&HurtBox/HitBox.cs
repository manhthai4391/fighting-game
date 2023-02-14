using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox : MonoBehaviour, IHitBoxBase
{
    AttackData attackData;

    public IAttackBase attack;

    public UnityAction<HitData> onHitEvent = delegate { };

    [HideInInspector]
    public string colliderTag;

    private void OnEnable()
    {
        if(attack != null)
            attackData = attack.CurrentAttack;
    }

    public void Hit(Transform target, HitData hitData)
    {
        if(target.TryGetComponent(out IHurtBoxBase hurtBox))
        {
            hurtBox.TakeDamage(hitData);
            onHitEvent?.Invoke(hitData);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(colliderTag))
            return;

        HitData data = new HitData();
        data.hitPoint = other.ClosestPoint(transform.position);
        data.attack = attackData;
        data.hurtBoxTransform = other.transform;
        Hit(other.transform, data);
    }
}
