using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GuardingFilter : MonoBehaviour, IGuardingBase
{
    public bool isGuarding;
    public bool isCrouching;

    public bool canGuard;

    public UnityAction<HitData> onHitEvent = delegate { };

    float elapsedTime = 0;   
    float maxTimeOut = 1.5f;

    [SerializeField]
    float parryThreshHold = 0.05f;

    public void Guard()
    {
        if (!canGuard)
            return;
        else
        {
            isGuarding = true;
        }
    }

    public void CheckBlocking(HitData hitData)
    {
        if(hitData.attack.hitboxType == HitboxType.PROXIMITY_HITBOX)
        {
            if (isGuarding)
                return;
            if(!canGuard)
            {
                EnableGuarding();
            }
        }
        else
        {
            if (!isGuarding)
            {
                hitData.wasBlocked = false;
            }
            else
            {
                if ((isCrouching && hitData.hurtBoxPosition == HurtBoxPosition.LOW) || (!isCrouching && hitData.hurtBoxPosition == HurtBoxPosition.HIGH))
                {
                    hitData.wasBlocked = true;
                    hitData.wasParry = elapsedTime < parryThreshHold;
                }
                else
                {
                    hitData.wasBlocked = false;
                    hitData.wasParry = false;
                }
            }
            DisableGuarding();
            onHitEvent.Invoke(hitData);
        }
        
    }

    void DisableGuarding()
    {
        StopCoroutine(CheckParryTimer());
        elapsedTime = 0;
        canGuard = false;
    }

    void EnableGuarding()
    {
        canGuard = true;
        elapsedTime = 0;
        StartCoroutine(CheckParryTimer());
    }

    IEnumerator CheckParryTimer()
    {
        canGuard = true;
        elapsedTime = 0;
        while(elapsedTime < maxTimeOut)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0;
        canGuard = false;
    }
}
