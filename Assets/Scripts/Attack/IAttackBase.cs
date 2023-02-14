using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackBase
{
    AttackData GetAttackData(string attackName);

    AttackData CurrentAttack { get; }
}
