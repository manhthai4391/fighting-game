using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerUGUI : UIManagerBase
{
    [SerializeField]
    Image[] healthBars;

    public override void RegisterHealthSliderChangeEvent()
    {
        int i = 0;
        foreach (Health health in healths)
        {
            Image healthBar = healthBars[i];
            healthBar.fillAmount = 1;
            health.onHealthValueChange += UpdateHealthSlider;
            i++;
        }
    }

    void UpdateHealthSlider() 
    {
        int i = 0;
        foreach (Image healthBar in healthBars)
        {
            healthBar.fillAmount = (float)healths[i].CurrentHealth / (float)healths[i].maxHealth;
            i++;
        }
    }

    public override void UnregisterHealthSliderChangeEvent()
    { 
        foreach(Health health in healths)
        {
            health.onHealthValueChange -= UpdateHealthSlider;
        }
    }
}
