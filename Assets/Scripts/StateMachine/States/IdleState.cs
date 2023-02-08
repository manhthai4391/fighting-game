using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Character character, float duration) : base(character, duration)
    {
    }

    public override void Move(Vector2 input)
    {
        character.Move(input);
        if(input.y > 0.1f)
        {
            character.SetState(new AirBorneState(character, 1));
        }
        else
        {
            character.SetState(new MovingState(character, 0));
        }
        
    }

    public override void Attack(string attackName)
    {
        character.Attack(attackName);
        character.SetState(new AttackState(character, 1));
    }

    public override void RightDash()
    {
        character.RightDash();
    }

    public override void LeftDash()
    {
       character.LeftDash();
    }
}
