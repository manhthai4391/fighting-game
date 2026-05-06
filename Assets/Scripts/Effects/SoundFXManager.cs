using UnityEngine;
using UnityEngine.Serialization;

public class SoundFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    [FormerlySerializedAs("audioSource")]
    private AudioSource _audioSource;

    [SerializeField]
    [FormerlySerializedAs("hitSound")]
    private AudioClip _hitSound;

    private void Start()
    {
        EffectsManager.OnHitEvent += PlayHitFX;
    }

    private void OnDestroy()
    {
        EffectsManager.OnHitEvent -= PlayHitFX;
    }

    public void PlayHitFX(HitData hitData)
    {
        float randomVolumeScale = Random.Range(0.75f, 1.0f);
        _audioSource.PlayOneShot(_hitSound, randomVolumeScale);
    }
}
