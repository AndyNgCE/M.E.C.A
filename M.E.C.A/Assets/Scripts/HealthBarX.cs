using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarX : MonoBehaviour
{
    public Image healthBar;
    private DamageSystem damageSystem;

    void Awake()
    {
        healthBar = transform.Find("HealthBar").GetComponent<Image>();
    }

    void Start()
    {
        damageSystem = new DamageSystem(100);
        SetHealth(damageSystem.GetHealth());
        damageSystem.OnDamaged += DamageSystem_OnDamaged;
    }

    private void DamageSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(damageSystem.GetHealth());
    }

    void SetHealth(float healthNormalized)
    {
        healthBar.fillAmount = healthNormalized;
    }

    /*public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Debug.Log("Dead");
        }
    }*/
}
