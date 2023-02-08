using UnityEngine;

public class AttackState : State
{
    public AttackState(Character character, float duration) : base(character, duration)
    {
    }

    bool hasEnded;

    public override void Start()
    {
        hasEnded = false;
        character.Invoke(nameof(TurnBackToIdleState), duration);
    }

    public override void OnExit()
    {
        if(!hasEnded)
        {
            character.CancelInvoke(nameof(TurnBackToIdleState));
            hasEnded = true;
        }
    }

    void TurnBackToIdleState()
    {
        character.SetState(character.idleState);
        hasEnded = true;
    }
 
    public override void Move(Vector2 input)
    {
        //cannot move
    }

    public override void Attack(string attackName)
    {
        //cannot attack
    }

    public override void RightDash()
    {
        //cannot dash
    }

    public override void LeftDash()
    {
        //canot dash
    }
}
