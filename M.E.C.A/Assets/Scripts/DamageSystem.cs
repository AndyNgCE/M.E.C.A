using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageSystem
{
    public event EventHandler OnDamaged;

    private int healthAmount;
    private int healthMax;

    public DamageSystem(int healthAmount)
    {
        healthMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    public void TakeDamage(int amount)
    {
        healthAmount -= amount;

        if(healthAmount < 0)
        {
            healthAmount = 0;
        }

        if(OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }

    public float GetHealth()
    {
        return (float)healthAmount / healthMax;
    }
}
