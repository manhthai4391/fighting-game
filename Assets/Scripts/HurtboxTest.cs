using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxTest : MonoBehaviour
{
    [SerializeField]
    HurtBox[] hurtboxes;
    // Start is called before the first frame update
    void Start()
    {
        foreach(HurtBox hurtbox in hurtboxes)
        {
            hurtbox.onHitEvent += OnHit;
        }
        
    }

    void OnHit(HitData hitData)
    {
        Debug.Log("Hit: " + hitData.attack.damage.ToString() + " on " + hitData.hurtBoxPosition.ToString());
    }

    void OnDisable()
    {
        foreach (HurtBox hurtbox in hurtboxes)
        {
            hurtbox.onHitEvent -= OnHit;
        }
    }
}
