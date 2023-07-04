using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    public void UpdateProgress(float progress)
    {
        slider.value = progress;
    }
}
