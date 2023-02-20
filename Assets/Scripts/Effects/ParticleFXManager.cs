using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    ParticleSystem[] hitEffects;

    void Start() 
    {
        EffectsManager.Instance.OnHitEvent += PlayHitFX;
    }

    private void OnDestroy()
    {
        EffectsManager.Instance.OnHitEvent -= PlayHitFX;
    }

    public void Play(Vector3 position)
    {
        foreach(ParticleSystem particle in hitEffects)
        {
            if(!particle.gameObject.activeInHierarchy)
                particle.gameObject.SetActive(true);
            particle.gameObject.transform.position = position;
            if(particle.isPlaying)
            {
                particle.time = 0;
            }
            particle.Play();
        }
    }

    public void PlayHitFX(HitData hitData)
    {
        Play(hitData.hitPoint);
    }
}
