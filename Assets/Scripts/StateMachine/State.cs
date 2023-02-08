using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character character;
    protected float duration;

    public State(Character character, float duration)
    {
        this.character = character;
        this.duration = duration;
    }

    protected State(Character character)
    {
        this.character = character;
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {

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

    public virtual void OnExit()
    {

    }
}
