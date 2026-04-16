using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    [FormerlySerializedAs("maxHealth")]
    public int MaxHealth;

    [FormerlySerializedAs("onHealthValueChange")]
    public UnityAction OnHealthValueChange = delegate { };

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        OnHealthValueChange.Invoke();
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        OnHealthValueChange.Invoke();
    }
}
