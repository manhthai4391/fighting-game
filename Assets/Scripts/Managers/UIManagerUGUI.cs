using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class UIManagerUGUI : UIManagerBase
{
    [SerializeField]
    [FormerlySerializedAs("healthBars")]
    private Image[] _healthBars;

    public override void RegisterHealthSliderChangeEvent()
    {
        int i = 0;
        foreach (Health health in Healths)
        {
            Image healthBar = _healthBars[i];
            healthBar.fillAmount = 1;
            health.OnHealthValueChange += UpdateHealthSlider;
            i++;
        }
    }

    private void UpdateHealthSlider() 
    {
        int i = 0;
        foreach (Image healthBar in _healthBars)
        {
            healthBar.fillAmount = (float)Healths[i].CurrentHealth / (float)Healths[i].MaxHealth;
            i++;
        }
    }

    public override void UnregisterHealthSliderChangeEvent()
    { 
        foreach(Health health in Healths)
        {
            health.OnHealthValueChange -= UpdateHealthSlider;
        }
    }
}
