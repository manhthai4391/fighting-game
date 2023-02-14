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
}
