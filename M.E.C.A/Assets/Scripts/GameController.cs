using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DeckModel player;
    public DeckModel dealer;
    public DeckModel spots;

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

    public void ChooseCard(int index)
    {
        spots.Push(player.Pop(index));  // 0 needs to be the card's index
        if(spots.CardCount >= 3)
        {
            Debug.Log("Deal Card Damage!");
            DealDamage(spots.HandValue());
        }
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            Debug.Log("Victory!!!"); // return to map scene with current progress
        }

        if(currentHealth <= 0)
        {
            Debug.Log("You have been defeated!"); // return to start of level (probably some sort of menu tbh)
        }
    }

    void StartGame()
    {
        for(int i = 0; i < 7; i++)
        {
            player.Push(dealer.Pop(0));
        }
    }
}
