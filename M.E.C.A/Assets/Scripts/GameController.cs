using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public DeckModel player;
    public DeckModel dealer;
    public DeckModel spots;
    //public DeckModel deckModel;
    
    public Text winnerText;
    public Text turnText;

    int condition = 1; // 0 when round over
    int turn = 1;

    public int prevNum = 0;
    public int numCardsPlayed = 0;
    public int firstNum = 0;

    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image healthBar;

    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth = 100;
    public Image enemyHealthBar;
    int damageToTake;
    // public int[] values = new int[3];
    public int card1;
    public int card2;
    public int card3;

    public void StartTurn()
    {
        if(condition == 0)
        {
            return;
        }

        player.GetComponent<DeckView>().Clear();
        spots.GetComponent<DeckView>().Clear();

        dealer.GetComponent<DeckView>().Clear();
        dealer.CreateDeck();

        player.numCard = 0;
        prevNum = 0;
        numCardsPlayed = 0;

        StartCoroutine(StartGame());
    }

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

    public IEnumerator ChooseCard(int index)
    {
        spots.Push(player.Pop(index));  // 0 needs to be the card's index

        if(spots.CardCount == 1)
        {
            card1 = spots.HandValue();
        }
        else if(spots.CardCount == 2)
        {
            card2 = spots.HandValue() - card1;
        }
        else
        {
            card3 = spots.HandValue() - card1 - card2;
        }

        if(spots.CardCount >= 3)
        {
            Debug.Log("Deal Card Damage!");
            //yield return new WaitForSeconds(0.5f);
            DealDamage(card1);
            //yield return new WaitForSeconds(0.5f);
            DealDamage(card2);
            //yield return new WaitForSeconds(0.5f);
            DealDamage(card3);
            StartCoroutine(EnemyTurn());
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator EnemyTurn()
    {
        if(condition == 1)
        {
            // make OnMouseDown for cards false
            for(int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                damageToTake = UnityEngine.Random.Range(8, 20);
                TakeDamage(damageToTake);
            }
            yield return new WaitForSeconds(1f);
            StartTurn();
        }
    }

    public void RemoveCard(int index)
    {
        player.Push(spots.Pop(index));
    }

    IEnumerator Victory()
    {
        if(condition == 1)
        {
            winnerText.text = "VICTORY!!!"; // return to map scene with current progress
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene(sceneName: "Travel Scene");
        }
    }

    IEnumerator Defeat()
    {
        if(condition == 1)
        {
            winnerText.text = "DEFEAT!!!"; // return to start of level (probably some sort of menu tbh)
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene(sceneName: "QuitButton");
        }
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            StartCoroutine(Victory());
        }

        if(currentHealth <= 0)
        {
            StartCoroutine(Defeat());
        }
    }

    IEnumerator StartGame()
    {
        turnText.text = "TURN " + turn;
        turn++;
        for(int i = 0; i < 7; i++)
        {
            player.Push(dealer.Pop(0));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
