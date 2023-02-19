using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;

    public void PlayHitFX(HitData hitData)
    {
        audioSource.PlayOneShot(hitSound);
    }
}
