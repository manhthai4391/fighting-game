using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public Health Health { get; private set; }
    public IAnimatorBase Animator { get; private set; }
    public IMovementBase Movement { get; private set; }
    public IAttackBase AttackComponent { get; private set; }

    public UnityAction OnCharacterDieEvent = delegate { };
    public UnityAction<HitData> OnCharacterHurtEvent = delegate { };

    public bool IsHurt { get; protected set; }
    public bool IsDead { get; protected set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        Animator = GetComponent<IAnimatorBase>();
        Movement = GetComponent<IMovementBase>();
        AttackComponent = GetComponent<IAttackBase>();
    }

    public virtual void Move(Vector2 input)
    {

    }

    public virtual void RightDash() 
    {
        
    }

    public virtual void LeftDash() 
    {
        
    }

    public virtual void Attack(string attackName) 
    {

    }

    public virtual void EnterHurtState()
    {
        IsHurt = true;
    }

    public virtual void ExitHurtState()
    {
        IsHurt = false;
    }

    public virtual void Die()
    {
        OnCharacterDieEvent?.Invoke();
        IsDead = true;
    }

    public virtual void Win()
    {

    }
}
