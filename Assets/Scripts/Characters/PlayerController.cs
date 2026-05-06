using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character, IHurtResponse
{
    private IInputReader _playerInput;

    private bool IgnoreInput()
    {
        return IsHurt || IsDead;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _playerInput = GetComponent<IInputReader>();
        InputBinding();
        RegisterHurtBoxes();
    }

    #region Input Binding
    private void InputBinding()
    {
        _playerInput.OnMoveLeftEvent += OnMoveLeft;
        _playerInput.OnMoveRightEvent += OnMoveRight;
        _playerInput.OnStopMovingEvent += OnStopMoving;
        _playerInput.OnRightDashEvent += OnRightDash;
        _playerInput.OnLeftDashEvent += OnLeftDash;
        _playerInput.OnAttackEvent += OnAttack;
    }

    private void OnMoveLeft()
    {
        if (IgnoreInput())
            return;
        Movement.MoveLeft();
        Animator.Move(Vector2.left);
    }

    private void OnMoveRight()
    {
        if (IgnoreInput())
            return;
        Movement.MoveRight();
        Animator.Move(Vector2.right);
    }
    private void OnStopMoving()
    {
        if (IgnoreInput())
            return;
        Movement.StopMoving();
        Animator.Move(Vector2.zero);
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
        _playerInput.OnMoveLeftEvent -= OnMoveLeft;
        _playerInput.OnMoveRightEvent -= OnMoveRight;
        _playerInput.OnStopMovingEvent -= OnStopMoving;
        _playerInput.OnRightDashEvent -= OnRightDash;
        _playerInput.OnLeftDashEvent -= OnLeftDash;
        _playerInput.OnAttackEvent -= OnAttack;
    }
    #endregion

    public override void Attack(string attackName)
    {
        if (IgnoreInput()) 
            return;
        _ = AttackComponent.GetAttackData(attackName);
        Animator.Attack(attackName);
    }

    public override void RightDash()
    {
        if (IgnoreInput())
            return;
        Movement.RightDash();
    }

    public override void LeftDash()
    {
        if (IgnoreInput())
            return;
        Movement.LeftDash();
    }

    #region Hurt
    public void RegisterHurtBoxes()
    {
        HurtBox[] hurtBoxes = GetComponentsInChildren<HurtBox>();
        foreach(HurtBox hurtBox in hurtBoxes)
        {
            hurtBox.OnHitEvent += OnGotHit;
        }
    }

    public void UnregisterHurtBoxes()
    {
        HurtBox[] hurtBoxes = GetComponentsInChildren<HurtBox>(true);
        foreach (HurtBox hurtBox in hurtBoxes)
        {
            hurtBox.OnHitEvent -= OnGotHit;
        }
    }

    public void OnGotHit(HitData hitData)
    {
        if(IsDead) 
            return;

        if(Health != null)
        {
            Health.TakeDamage(hitData.Attack.Damage);
            if (Health.CurrentHealth <= 0)
            {
                Die();
            }
        }
        
        Animator.Hurt(hitData.HurtBoxPosition);
        EffectsManager.OnHitEvent?.Invoke(hitData);
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
        Animator.Die();

        //clear movement input
        Movement.StopMoving();
        Movement.CannotMove = true;

        OnCharacterDieEvent?.Invoke();
    }

    public override void Win()
    {
        Animator.Win();
    }

    private void OnDestroy()
    {
        UnBindInput();
        UnregisterHurtBoxes();
    }
}
