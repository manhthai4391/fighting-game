using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EffectsManager : MonoBehaviour, IEffectsManagerBase
{
    public static UnityAction<HitData> OnHitEvent { get; set; }
}
