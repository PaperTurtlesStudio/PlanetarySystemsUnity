using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public HealthBar HUDHealthBar;
    public HealthBar ZipComHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        ZipComHealthBar.SetMaxHealth(MaxHealth);
        HUDHealthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ZipComHealthBar.SetHealth(TakeDamage(5.0f));
            HUDHealthBar.SetHealth(TakeDamage(5.0f));
        }
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}
