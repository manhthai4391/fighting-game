using System.Collections;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public float maxTimeOut = 0.5f;

    public float LastUpInput { get; private set; }
    public float LastDownInput { get; private set; }
    public float LastLeftInput { get; private set; }
    public float LastRightInput { get; private set; }

    float lastInput = 0.0f;
    bool isCountingDown;

    private void Start()
    {
        ResetRecord();
    }

    public void Move(Vector2 input)
    {
        if (input == Vector2.zero)
            return;

        Record(input);

        if (!isCountingDown)
        {
            StartCoroutine(CountDown());
        }
    }

    void Record(Vector2 input)
    {
        //TODO: RECORD INPUT
        if(input.x > float.Epsilon)
        {
            LastRightInput = 0.0f;
        }
        else if(input.x < -float.Epsilon)
        {
            LastLeftInput = 0.0f;
        }

        if(input.y > float.Epsilon)
        {
            LastUpInput = 0.0f;
        }
        else if(input.y < - float.Epsilon)
        {
            LastDownInput = 0.0f;
        }

        lastInput = 0.0f;
    }

    public void ResetRecord() 
    {
        LastUpInput = LastDownInput = LastLeftInput = LastRightInput = lastInput = maxTimeOut;
    }

    IEnumerator CountDown()
    {
        isCountingDown = true;
        while(lastInput < maxTimeOut)
        {
            lastInput += Time.deltaTime;

            if (LastUpInput < maxTimeOut)
                LastUpInput += Time.deltaTime;

            if (LastDownInput < maxTimeOut)
                LastDownInput += Time.deltaTime;

            if (LastLeftInput < maxTimeOut)
                LastLeftInput += Time.deltaTime;

            if (LastRightInput < maxTimeOut)
                LastRightInput += Time.deltaTime;

            yield return null;
        }
        isCountingDown = false;
        ResetRecord();
    }
}
