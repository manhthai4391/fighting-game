using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    ParticleSystem[] effects;

    public void Play(Vector3 position)
    {
        foreach(ParticleSystem particle in effects)
        {
            if(!particle.gameObject.activeInHierarchy)
                particle.gameObject.SetActive(true);
            particle.gameObject.transform.position = position;
            if (!particle.isPlaying)
                particle.Play();
        }
    }

    public void PlayHitFX(HitData hitData)
    {
        Play(hitData.hitPoint);
    }
}
