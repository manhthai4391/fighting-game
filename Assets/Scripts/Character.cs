using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Character : MonoBehaviour
{
    [HideInInspector]
    public Health health;
    public IAnimatorBase animator;
    public IMovementBase movement;
    public IAttackBase attack;

    public bool IsHurt { get; protected set; }

    void Awake()
    {
        health = GetComponent<Health>();
        animator = GetComponent<IAnimatorBase>();
        movement = GetComponent<IMovementBase>();
        attack = GetComponent<IAttackBase>();
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
}
