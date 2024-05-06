using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputRecorder : MonoBehaviour
{
    public float inputDelayTime = 0.5f;

    public Combo[] combos;

    public UnityAction<Combo> onComboExecute;

    private int[] currentComboKey;

    private float lastInputTime;

    private bool checkExecuteCombo;

    private void Start()
    {
        if(combos != null && combos.Length > 0)
        {
            //initialize
            currentComboKey = new int[combos.Length];

            for (int i = 0; i < combos.Length; i++)
            {
                currentComboKey[i] = 0;
            }
        }
    }

    public void CheckCombo(Vector2 input)
    {
        for (int i = 0; i < combos.Length; i++)
        {
            if (currentComboKey[i] < combos[i].inputCombos.Length)
            {
                if (CheckDirectionInput(input, combos[i].inputCombos[currentComboKey[i]]))
                {
                    ComboKeyMatched(i);
                }
            }
        }
    }

    public void CheckCombo(string input)
    {
        for(int i = 0; i < combos.Length; i++)
        {
            if (currentComboKey[i] < combos[i].inputCombos.Length)
            {
                if (combos[i].inputCombos[currentComboKey[i]].ToString() == input)
                {
                    ComboKeyMatched(i);
                }
                else
                {
                    ResetCombo(i);
                }
            }
            else
            {
                ResetCombo(i);
            }
        }
    }

    private void Update()
    {
        if(checkExecuteCombo)
        {
            if(Time.time - lastInputTime > inputDelayTime)
            {
                ExecuteCombo();
            }
        }
    }

    public void ExecuteCombo()
    {
        for(int i = 0; i < combos.Length; i++)
        {
            if (currentComboKey[i] == combos[i].inputCombos.Length)
            {
                onComboExecute?.Invoke(combos[i]);
                break;
            }
        }
    }

    private bool CheckDirectionInput(Vector2 input, InputCombo comboKey)
    {
        bool keyMatched = false;
        switch(comboKey)
        {
            case InputCombo.FORWARD:
                break;
            case InputCombo.BACKWARD:
                break;
            case InputCombo.UP:
                break;
            case InputCombo.DOWN:
                break;
            default:
                break;
        }
        return keyMatched;
    }

    private void ComboKeyMatched(int comboIndex)
    {
        currentComboKey[comboIndex]++;
        if (currentComboKey[comboIndex] == combos[comboIndex].inputCombos.Length)
        {
            checkExecuteCombo = true;
            lastInputTime = Time.time;
        }
    }

    private void ResetCombo(int comboIndex)
    {
        currentComboKey[comboIndex] = 0;
    }
}
