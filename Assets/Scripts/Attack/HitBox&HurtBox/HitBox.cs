using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox : MonoBehaviour, IHitBoxBase
{
    public string hitBoxName;

    public AttackData attackData;

    public UnityAction<HitData> onHitEvent = delegate { };

    public string colliderTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hit(Transform target, HitData hitData)
    {
        if(target.TryGetComponent(out IHurtBoxBase hurtBox))
        {
            hurtBox.TakeDamage(hitData);
            onHitEvent.Invoke(hitData);
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
