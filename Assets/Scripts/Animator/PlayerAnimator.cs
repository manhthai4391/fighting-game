using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IAnimatorBase
{
    readonly int moveBoolID = Animator.StringToHash("Move");
    readonly int verticalFloatID = Animator.StringToHash("Vertical");
    readonly int horizontalFloatID = Animator.StringToHash("Horizontal");
    readonly int backDashTriggerID = Animator.StringToHash("BackDash");
    readonly int forwardDashTriggerID = Animator.StringToHash("Dash");
    readonly int hurtTriggerID = Animator.StringToHash("Hurt");

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetFloat(horizontalFloatID, input.x);
        }
        animator.SetFloat(verticalFloatID, input.y);
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
        animator.SetTrigger(attackTrigger);
    }

    public void Hurt(HurtBoxPosition hurtBoxPosition)
    {
        animator.SetTrigger(hurtTriggerID);
        //LOW is 0, MIDDLE is 1, HIGH is 2
        float hitBoxVertical = (int)hurtBoxPosition;
        animator.SetFloat(verticalFloatID, hitBoxVertical);
    }
}
