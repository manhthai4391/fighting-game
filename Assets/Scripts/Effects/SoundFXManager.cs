using UnityEngine;

public class SoundFXManager : MonoBehaviour, IHitFXBase
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip hitSound;

    void Start()
    {
        EffectsManager.Instance.OnHitEvent += PlayHitFX;
    }

    private void OnDestroy()
    {
        EffectsManager.Instance.OnHitEvent -= PlayHitFX;
    }

    public void PlayHitFX(HitData hitData)
    {
        float randomVolumeScale = Random.Range(0.75f, 1.0f);
        audioSource.PlayOneShot(hitSound, randomVolumeScale);
    }
}
