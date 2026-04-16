using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class HitBox : MonoBehaviour, IHitBoxBase
{
    [FormerlySerializedAs("attack")]
    public IAttackBase Attack;

    [FormerlySerializedAs("onHitEvent")]
    public UnityAction<HitData> OnHitEvent = delegate { };

    [HideInInspector]
    [FormerlySerializedAs("colliderTag")]
    public string ColliderTag;

    private AttackData _attackData;

    private void OnEnable()
    {
        if(Attack != null)
            _attackData = Attack.CurrentAttack;
    }

    public void Hit(Transform target, HitData hitData)
    {
        if(target.TryGetComponent(out IHurtBoxBase hurtBox))
        {
            hurtBox.TakeDamage(hitData);
            OnHitEvent?.Invoke(hitData);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ColliderTag))
            return;

        HitData data = new HitData();
        data.HitPoint = other.ClosestPoint(transform.position);
        data.Attack = _attackData;
        data.HurtBoxTransform = other.transform;
        Hit(other.transform, data);
    }
}
