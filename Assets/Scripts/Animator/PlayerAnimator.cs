using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IAnimatorBase
{
    readonly int moveBoolID = Animator.StringToHash("Move");
    readonly int jumpTriggerID = Animator.StringToHash("Jump");
    readonly int verticalFloatID = Animator.StringToHash("Vertical");
    readonly int horizontalFloatID = Animator.StringToHash("Horizontal");
    readonly int backDashTriggerID = Animator.StringToHash("BackDash");
    readonly int forwardDashTriggerID = Animator.StringToHash("Dash");
    readonly int hurtTriggerID = Animator.StringToHash("Hurt");
    readonly int intensityFloatID = Animator.StringToHash("Intensity");
    readonly int punchTriggerID = Animator.StringToHash("Punch");
    readonly int kickTriggerID = Animator.StringToHash("Kick");

    Animator animator;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
