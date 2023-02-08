using System.Collections;
using UnityEngine;

public class MovingState : State
{
    public MovingState(Character character, float duration) : base(character, duration)
    {
    }

    public override void Start()
    {
        Debug.Log("Moving");
    }

    public override void Move(Vector2 input)
    {
        if (input == Vector2.zero)
        {
            character.SetState(character.idleState);
        }
        else if(input.y > 0.1f)
        {
            character.SetState(character.airBorneState);
        }
        character.Move(input);
    }

    public override void Attack(string attackName)
    {
        character.Attack(attackName);
    }

    public override void RightDash()
    {
        character.RightDash();
    }

    public override void LeftDash()
    {
        character.LeftDash();
    }

    public override void OnExit()
    {
        Debug.Log("exit moving");
        character.Move(Vector2.zero);
    }
}
