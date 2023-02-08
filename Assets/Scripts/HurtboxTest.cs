using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxTest : MonoBehaviour
{
    HurtBox hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        hurtbox = GetComponent<HurtBox>();
        hurtbox.onHitEvent += OnHit;
    }

    void OnHit(HitData hitData)
    {
        Debug.Log("Hit: " + hitData.attack.damage.ToString());
    }

    void OnDisable()
    {
        hurtbox.onHitEvent -= OnHit;
    }
}
