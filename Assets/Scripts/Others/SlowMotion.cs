using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField]
    float timeScale = 0.3f;
    [SerializeField]
    float duration = 2f;

    public void StartSlowMotion()
    {
        StartCoroutine(SlowMo());
    }

    IEnumerator SlowMo() 
    {
        Time.timeScale = timeScale;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1;
    }
}
