using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    [FormerlySerializedAs("hitEffects")]
    private ParticleSystem[] _hitEffects;

    private void Start() 
    {
        EffectsManager.OnHitEvent += PlayHitFX;
    }

    private void OnDestroy()
    {
        EffectsManager.OnHitEvent -= PlayHitFX;
    }

    public void Play(Vector3 position)
    {
        foreach(ParticleSystem particle in _hitEffects)
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
        Play(hitData.HitPoint);
    }
}
