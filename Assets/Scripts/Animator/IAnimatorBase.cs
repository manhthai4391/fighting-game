using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatorBase 
{
    void Move(Vector2 input);
    void Jump();
    void LeftDash();
    void RightDash();
    void Attack(string attackTrigger);
    void Hurt(HurtBoxPosition hurtBoxPosition);
    void Die();
    void Win();
}
