using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour, IAttackBase
{
    public AttackData CurrentAttack { get; private set; }

    [SerializeField]
    [FormerlySerializedAs("attacks")]
    private AttackData[] _attacks;

    [SerializeField]
    [FormerlySerializedAs("hitBoxes")]
    private HitBox[] _hitBoxes;

    private Dictionary<string, AttackData> _attackDictionary;

    // Start is called before the first frame update
    private void Start()
    {
        _attackDictionary = new Dictionary<string, AttackData>();
        foreach(var attack in _attacks)
        {
            _attackDictionary.Add(attack.AttackName, attack);
        }
        _attacks = null;

        foreach(var hit in _hitBoxes)
        {
            hit.gameObject.SetActive(false);
            hit.ColliderTag = gameObject.tag;
            hit.Attack = this;
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
