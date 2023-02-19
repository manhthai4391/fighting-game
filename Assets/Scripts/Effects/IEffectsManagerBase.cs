using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEffectsManagerBase 
{
    public UnityAction<HitData> OnHitEvent { get; set; }
    static IEffectsManagerBase Instance;
}
