using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EffectsManager : MonoBehaviour, IEffectsManagerBase
{
    public UnityAction<HitData> OnHitEvent { get; set; }

    public static EffectsManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
