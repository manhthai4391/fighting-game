using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    public int maxHealth;

    public UnityAction onHealthValueChange = delegate { };

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        onHealthValueChange.Invoke();
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        onHealthValueChange.Invoke();
    }
}
