using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character, IHurtResponse
{
    IInputReader playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<IInputReader>();
        InputBinding();
    }

    #region Input Binding
    void InputBinding()
    {
        playerInput.OnMoveEvent += OnMove;
        playerInput.OnRightDashEvent += OnRightDash;
        playerInput.OnLeftDashEvent += OnLeftDash;
        playerInput.OnAttackEvent += OnAttack;
    }

    void OnMove(Vector2 input)
    {
        Move(input);
    }

    void OnAttack(string attackName)
    {
        Attack(attackName);
    }

    void OnRightDash()
    {
        RightDash();
    }

    void OnLeftDash()
    {
        LeftDash();
    }

    void UnBindInput()
    {
        playerInput.OnMoveEvent -= OnMove;
        playerInput.OnRightDashEvent -= OnRightDash;
        playerInput.OnLeftDashEvent -= OnLeftDash;
        playerInput.OnAttackEvent -= OnAttack;
    }
    #endregion

    public override void Move(Vector2 input)
    {
        if(input.y > 0.1f && movement.Grounded)
        {
            movement.Jump();
            animator.Jump();
        }
        movement.Move(input);
        animator.Move(input);
    }

    public override void Attack(string attackName)
    {
        AttackData attackData = attack.GetAttackData(attackName);
        //play animation
        animator.Attack(attackName);
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
        }
    }

    void OnDestroy()
    {
        UnBindInput();
    }
}
