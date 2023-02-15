using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackBase
{
    [SerializeField]
    AttackData[] attacks;

    public AttackData CurrentAttack { get; private set; }

    Dictionary<string, AttackData> attackList;

    [SerializeField]
    HitBox[] hitBoxes;

    // Start is called before the first frame update
    void Start()
    {
        attackList = new Dictionary<string, AttackData>();
        foreach(var attack in attacks)
        {
            attackList.Add(attack.attackName, attack);
        }
        attacks = null;

        foreach(var hit in hitBoxes)
        {
            hit.gameObject.SetActive(false);
            hit.colliderTag = gameObject.tag;
            hit.attack = this;
        }
    }

    public AttackData GetAttackData(string attackName)
    {
        if (!attackList.ContainsKey(attackName))
            return default;
        else 
        {
            CurrentAttack = attackList[attackName];
            return CurrentAttack;
        } 
    }
}
