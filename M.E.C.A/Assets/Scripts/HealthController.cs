using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image healthBar;

    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth = 100;
    public Image enemyHealthBar;

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        Debug.Log("Current Health: " + currentHealth);
    }

    public void DealDamage(int damageAmount)
    {
        Debug.Log("Damage Dealt");
        enemyCurrentHealth -= damageAmount;
        enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
    }
}
