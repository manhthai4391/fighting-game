using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEffectsManagerBase 
{
    public static UnityAction<HitData> OnHitEvent { get; set; }
}
