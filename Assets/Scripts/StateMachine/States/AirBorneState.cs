using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBorneState : State
{
    public AirBorneState(Character character, float duration) : base(character, duration)
    {
    }

    public override void Update()
    {
        if(character.movement.Grounded)
        {
            character.SetState(character.idleState);
        }
    }

    public override void Move(Vector2 input)
    {
        character.Move(input);
    }

    public override void Attack(string attackName)
    {
        character.Attack(attackName);
    }

    public override void RightDash()
    {
        //cannot dash in mid-air
    }

    public override void LeftDash()
    {
        //cannot dash in mid-air
    }
}
