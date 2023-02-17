using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character, IHurtResponse
{
    IInputReader playerInput;
    InputRecorder inputRecorder;

    bool IgnoreInput()
    {
        return IsHurt || IsDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<IInputReader>();
        inputRecorder = GetComponent<InputRecorder>();
        InputBinding();
        RegisterHurtBoxes();

        hitFX = GetComponent<IHitFXBase>();
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
        if (IgnoreInput())
            return;
        if(input.y > 0.1f && movement.Grounded)
        {
            movement.Jump();
            animator.Jump();
        }
        inputRecorder.Move(input);
        movement.Move(input);
        animator.Move(input);
    }

    public override void Attack(string attackName)
    {
        if (IgnoreInput()) 
            return;
        _ = attack.GetAttackData(attackName);
        //play animation
        animator.Attack(attackName);
        //TO DO: ADD INPUT COMBO
    }

    public override void RightDash()
    {
        if (IgnoreInput())
            return;
        movement.RightDash();
    }

    public override void LeftDash()
    {
        if (IgnoreInput())
            return;
        movement.LeftDash();
    }

    public void RegisterHurtBoxes()
    {
        HurtBox[] hurtBoxes = GetComponentsInChildren<HurtBox>();
        foreach(HurtBox hurtBox in hurtBoxes)
        {
            hurtBox.onHitEvent += OnGotHit;
        }
    }

    public void UnregisterHurtBoxes()
    {
        HurtBox[] hurtBoxes = GetComponentsInChildren<HurtBox>(true);
        foreach (HurtBox hurtBox in hurtBoxes)
        {
            hurtBox.onHitEvent -= OnGotHit;
        }
    }

    public void OnGotHit(HitData hitData)
    {
        health.TakeDamage(hitData.attack.damage);
        animator.Hurt(hitData.hurtBoxPosition);
        hitFX.PlayFX(hitData.hitPoint);
        if(health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    public override void EnterHurtState()
    {
        IsHurt = true;
    }

    public override void ExitHurtState()
    {
        IsHurt = false;
    }

    public override void Die()
    {
        IsDead = true;
        animator.Die();
        onCharacterDieEvent?.Invoke();
    }

    public override void Win()
    {
        animator.Win();
        movement.CannotMove = true;
    }

    void OnDestroy()
    {
        UnBindInput();
        UnregisterHurtBoxes();
    }
}
