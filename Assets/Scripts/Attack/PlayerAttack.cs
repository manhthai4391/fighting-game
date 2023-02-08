using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackBase
{
    [SerializeField]
    AttackData[] attacks;

    AttackData currentAttack;

    Dictionary<string, AttackData> attackList;

    [SerializeField]
    HitBox[] hitBoxes;

    Dictionary<string, HitBox> hitboxList;

    // Start is called before the first frame update
    void Start()
    {
        attackList = new Dictionary<string, AttackData>();
        foreach(var attack in attacks)
        {
            attackList.Add(attack.attackName, attack);
        }
        attacks = null;

        hitboxList = new Dictionary<string, HitBox>();
        foreach(var hit in hitBoxes)
        {
            hitboxList.Add(hit.hitBoxName, hit);
            hit.gameObject.SetActive(false);
            hit.colliderTag = gameObject.tag;
        }
    }

    public AttackData GetAttackData(string attackName)
    {
        if (!attackList.ContainsKey(attackName))
            return default;
        else 
        {
            currentAttack = attackList[attackName];
            return currentAttack;
        } 
    }

    public void EnableHitBox(string hitBoxName)
    {
        if(hitboxList.ContainsKey(hitBoxName))
        {
            hitboxList[hitBoxName].attackData = currentAttack;
            hitboxList[hitBoxName].gameObject.SetActive(true);
        }
    }

    public void DisableHitBox(string hitBoxName)
    {
        if (hitboxList.ContainsKey(hitBoxName))
        {
            hitboxList[hitBoxName].gameObject.SetActive(false);
        }
    }
}
