﻿using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IAnimatorBase
{
    [SerializeField]
    private int playerIndex = 0;

    [SerializeField]
    private Animator[] charactersAnimator;

    private readonly int moveBoolID = Animator.StringToHash("Move");
    private readonly int jumpTriggerID = Animator.StringToHash("Jump");
    private readonly int verticalFloatID = Animator.StringToHash("Vertical");
    private readonly int horizontalFloatID = Animator.StringToHash("Horizontal");
    private readonly int backDashTriggerID = Animator.StringToHash("BackDash");
    private readonly int forwardDashTriggerID = Animator.StringToHash("Dash");
    private readonly int hurtTriggerID = Animator.StringToHash("Hurt");
    private readonly int intensityFloatID = Animator.StringToHash("Intensity");
    private readonly int punchTriggerID = Animator.StringToHash("Punch");
    private readonly int kickTriggerID = Animator.StringToHash("Kick");

    private const string selectedCharacterPlayerPrefKey = "SELECTED_CHARACTER_PLAYER_";

    private Animator animator;

    private bool facingRight = true;

    // Start is called before the first frame update
    private void Start()
    {
        string key = selectedCharacterPlayerPrefKey + playerIndex;
        int selectedCharacterID = PlayerPrefs.GetInt(key, 0);

        for(int i = 0; i < charactersAnimator.Length; i++)
        {
            charactersAnimator[i].gameObject.SetActive(i == selectedCharacterID);
        }
        animator = charactersAnimator[selectedCharacterID];

        facingRight = transform.forward.x > 0;
    }

    public void Move(Vector2 input)
    {
        if(Mathf.Approximately(input.x, 0.0f))
        {
            animator.SetBool(moveBoolID, false);
        }
        else
        {
            animator.SetBool(moveBoolID, true);
            if(facingRight)
            {
                animator.SetFloat(horizontalFloatID, input.x);
            }
            else
            {
                animator.SetFloat(horizontalFloatID, -input.x);
            }
        }
        animator.SetFloat(verticalFloatID, input.y);
    }

    public void Jump()
    {
        animator.SetTrigger(jumpTriggerID);
    }
  
    public void LeftDash()
    {
        animator.SetTrigger(backDashTriggerID);
    }

    public void RightDash()
    {
        animator.SetTrigger(forwardDashTriggerID);
    }

    public void Attack(string attackTrigger) 
    { 
        switch (attackTrigger)
        {
            case "LIGHT_PUNCH":
                animator.SetFloat(intensityFloatID, 0);
                animator.SetTrigger(punchTriggerID);
                break;
            case "LIGHT_KICK":
                animator.SetFloat(intensityFloatID, 0);
                animator.SetTrigger(kickTriggerID);
                break;
            case "MEDIUM_PUNCH":
                animator.SetFloat(intensityFloatID, 1);
                animator.SetTrigger(punchTriggerID);
                break;
            case "MEDIUM_KICK":
                animator.SetFloat(intensityFloatID, 1);
                animator.SetTrigger(kickTriggerID);
                break;
            case "HEAVY_PUNCH":
                animator.SetFloat(intensityFloatID, 2);
                animator.SetTrigger(punchTriggerID);
                break;
            case "HEAVY_KICK":
                animator.SetFloat(intensityFloatID, 2);
                animator.SetTrigger(kickTriggerID);
                break;
        }
    }

    public void Hurt(HurtBoxPosition hurtBoxPosition)
    {
        animator.SetTrigger(hurtTriggerID);
        //LOW is 0, MIDDLE is 1, HIGH is 2
        float hitBoxVertical = (int)hurtBoxPosition;
        animator.SetFloat(verticalFloatID, hitBoxVertical);
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        animator.ResetTrigger(hurtTriggerID);
        animator.SetBool(moveBoolID, false);
    }
    public void Win()
    {
        animator.SetTrigger("Win");
    }
}
