using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtResponse 
{
    void RegisterHurtBoxes();
    void UnregisterHurtBoxes();
    void OnGotHit(HitData hitData);
}
