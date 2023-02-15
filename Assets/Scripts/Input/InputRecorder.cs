using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputRecorder : MonoBehaviour
{
    public float maxTimeOut = 0.5f;

    public bool Up { get; private set; }
    public bool Down { get; private set; }
    public bool Left { get; private set; }
    public bool Right { get; private set; }

    float elapsedTime = 0.0f;
    bool shouldRefresh;
    bool isCountingDown;

    public void Move(Vector2 input)
    {
        if (input == Vector2.zero)
            return;

        shouldRefresh = true;
        if(!isCountingDown)
        {
            StartCoroutine(CountDown());
        }

        Record(input);
    }

    void Record(Vector2 input)
    {
        //TODO: RECORD INPUT
    }

    void ResetRecord() 
    {
        //TODO: RESET RECORD
    }

    IEnumerator CountDown()
    {
        isCountingDown = true;
        while(elapsedTime < maxTimeOut)
        {

            if(!shouldRefresh)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0.0f;
                shouldRefresh = false;
            }
            yield return null;
        }
        isCountingDown = false;
        elapsedTime = 0.0f;
        shouldRefresh = false;
        ResetRecord();
    }
}
