using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character, IHurtResponse
{
    IInputReader playerInput;

    // Start is called before the first frame update
    void Start()
    {
        idleState = new IdleState(this, 0);
        airBorneState = new AirBorneState(this, 0);
        SetState(idleState);

        playerInput = GetComponent<IInputReader>();
        InputBinding();
    }

    #region Input Binding
    void InputBinding()
    {
        playerInput.OnMoveEvent += OnMove;
        playerInput.OnAttackEvent += OnAttack;
        playerInput.OnRightDashEvent += OnRightDash;
        playerInput.OnLeftDashEvent += OnLeftDash;
    }

    void OnMove(Vector2 input)
    {
        CurrentState.Move(input);
    }

    void OnAttack(string attackName)
    {
        CurrentState.Attack(attackName);
    }

    void OnRightDash()
    {
        CurrentState.RightDash();
    }

    void OnLeftDash()
    {
        CurrentState.LeftDash();
    }

    void UnBindInput()
    {
        playerInput.OnMoveEvent -= OnMove;
        playerInput.OnAttackEvent -= OnAttack;
        playerInput.OnRightDashEvent -= OnRightDash;
        playerInput.OnLeftDashEvent -= OnLeftDash;
    }
    #endregion

    public override void Move(Vector2 input)
    {
        movement.Move(input);
        animator.Move(input);
    }

    public override void Attack(string attackName)
    {
        AttackData attackData = attack.GetAttackData(attackName);
        //play animation
        //TO DO: ADD INPUT COMBO
    }

    public override void RightDash()
    {
        movement.RightDash();
    }

    public override void LeftDash()
    {
        movement.LeftDash();
    }

    public void OnGotHit(HitData hitData)
    {
        if(hitData.wasParry)
        {

        }
        else if(hitData.wasBlocked)
        {
            health.TakeDamage(hitData.attack.chipDamage);
            //play block animation
        }
        else
        {
            health.TakeDamage(hitData.attack.damage);
            animator.Hurt(hitData.hurtBoxPosition);
            SetState(new HurtState(this, hitData.attack.stun));
        }
    }

    void OnDestroy()
    {
        UnBindInput();
    }
}
