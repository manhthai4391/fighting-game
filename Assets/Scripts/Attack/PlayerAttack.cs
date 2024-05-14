using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackBase
{
    public AttackData CurrentAttack { get; private set; }

    [SerializeField]
    private AttackData[] attacks;

    [SerializeField]
    private HitBox[] hitBoxes;

    private Dictionary<string, AttackData> _attackDictionary;

    // Start is called before the first frame update
    void Start()
    {
        _attackDictionary = new Dictionary<string, AttackData>();
        foreach(var attack in attacks)
        {
            _attackDictionary.Add(attack.attackName, attack);
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
        if (!_attackDictionary.ContainsKey(attackName))
            return default;
        else 
        {
            CurrentAttack = _attackDictionary[attackName];
            return CurrentAttack;
        } 
    }
}
