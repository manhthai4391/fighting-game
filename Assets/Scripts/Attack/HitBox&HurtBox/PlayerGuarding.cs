using UnityEngine;

public class PlayerGuarding : MonoBehaviour
{
    public float blockingThreshold = 0.4f;

    public float parryThreshold = 0.25f;

    bool FacingRight(Transform transform)
    {
        if (transform.rotation.eulerAngles.y == 90)
        {
            return true;
        }    
        else 
        { 
            return false; 
        }
    }

    public bool CheckBlocking(Transform transform, InputRecorder recorder, out bool parry)
    {
        //if the player is facing the right
        if(FacingRight(transform))
        {
            if(recorder.LastLeftInput < parryThreshold)
            {
                parry = true;
                return true;
            }
            else if(recorder.LastLeftInput < blockingThreshold)
            {
                parry = false;
                return true;
            }
            else
            {
                parry = false;
                return false;
            }
        }
        else
        {
            if(recorder.LastRightInput < parryThreshold)
            {
                parry = true;
                return true;
            }
            else if(recorder.LastRightInput < blockingThreshold)
            {
                parry = false;
                return true;
            }
            else 
            {
                parry = false;
                return false;
            }
        }
    }
}
