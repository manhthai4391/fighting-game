using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IdleState idleState;
    public AirBorneState airBorneState;

    public State CurrentState { get { return currentState; } }
    protected State currentState;

    public void SetState(State state)
    {
        currentState?.OnExit();
        currentState = state;
        state.Start();
    }
}
