using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combatants : MonoBehaviour
{
    public float startHealth = 100;
    private float health;
    public float currentHealth;

    private Cards cards;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
