using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("slider")]
    private Slider _slider;

    public void UpdateProgress(float progress)
    {
        _slider.value = progress;
    }
}
