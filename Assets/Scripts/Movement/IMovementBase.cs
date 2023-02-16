using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBase 
{
    bool CannotMove { get; set; }
    bool Grounded { get; }
    void Move(Vector2 input);
    void Jump();
    void LeftDash();
    void RightDash();
}
