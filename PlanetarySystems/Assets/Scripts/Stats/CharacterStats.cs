using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float MaxHealth = 100.0f;
    [SerializeField]
    public float CurrentHealth { get; private set; }
    

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public float TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;

        Debug.Log(gameObject.name + " is taking " + Damage.ToString() + " damage");

        if (CurrentHealth <= 0)
        {
            Die();
        }

        return CurrentHealth;
    }

    public virtual void Die()
    {
        Debug.Log(gameObject.name + " has died");
    }
}
