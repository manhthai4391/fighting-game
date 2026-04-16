using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SlowMotion : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("timeScale")]
    private float _timeScale = 0.3f;
    [SerializeField]
    [FormerlySerializedAs("duration")]
    private float _duration = 2f;

    public void StartSlowMotion()
    {
        StartCoroutine(SlowMo());
    }

    private IEnumerator SlowMo() 
    {
        Time.timeScale = _timeScale;
        yield return new WaitForSeconds(_duration);
        Time.timeScale = 1;
    }
}
