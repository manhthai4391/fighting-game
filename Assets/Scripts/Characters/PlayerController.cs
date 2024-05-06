using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character, IHurtResponse
{
    private IInputReader playerInput;

    private bool IgnoreInput()
    {
        return IsHurt || IsDead;
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<IInputReader>();
        InputBinding();
        RegisterHurtBoxes();
    }

    #region Input Binding
    private void InputBinding()
    {
        playerInput.OnMoveEvent += OnMove;
        playerInput.OnRightDashEvent += OnRightDash;
        playerInput.OnLeftDashEvent += OnLeftDash;
        playerInput.OnAttackEvent += OnAttack;
    }

    private void OnMove(Vector2 input)
    {
        Move(input);
    }

    private void OnAttack(string attackName)
    {
        Attack(attackName);
    }

    private void OnRightDash()
    {
        RightDash();
    }

    private void OnLeftDash()
    {
        LeftDash();
    }

    private void UnBindInput()
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
        movement.Move(input);
        animator.Move(input);
    }

    public override void Attack(string attackName)
    {
        if (IgnoreInput()) 
            return;
        _ = attack.GetAttackData(attackName);
        animator.Attack(attackName);
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

    #region Hurt
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
        if(IsDead) 
            return;

        if(health != null)
        {
            health.TakeDamage(hitData.attack.damage);
            if (health.CurrentHealth <= 0)
            {
                Die();
            }
        }
        
        animator.Hurt(hitData.hurtBoxPosition);
        EffectsManager.Instance.OnHitEvent?.Invoke(hitData);
    }

    public override void EnterHurtState()
    {
        IsHurt = true;
    }

    public override void ExitHurtState()
    {
        IsHurt = false;
    }
    #endregion

    public override void Die()
    {
        StartCoroutine(Dead());
    }

    private IEnumerator Dead()
    {
        yield return new WaitForEndOfFrame();
        IsDead = true;
        animator.Die();

        //clear movement input
        movement.Move(Vector2.zero);
        movement.CannotMove = true;

        onCharacterDieEvent?.Invoke();
    }

    public override void Win()
    {
        animator.Win();
    }

    private void OnDestroy()
    {
        UnBindInput();
        UnregisterHurtBoxes();
    }
}
