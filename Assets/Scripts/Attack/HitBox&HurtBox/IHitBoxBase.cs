using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitBoxBase 
{
    void Hit(Transform target, HitData hitData);
}
