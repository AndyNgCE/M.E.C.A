using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // The deck, player's hand, and cards chosen
    public DeckModel player;
    public DeckModel dealer;
    public DeckModel spots;
    //public DeckModel deckModel;
    
    // UI text
    public Text winnerText;
    public Text turnText;
    public Text playerTurnText;

    public Text damage1;
    public Text damage2;
    public Text damage3;

    public Text playerDamage1;
    public Text playerDamage2;
    public Text playerDamage3;

    public Text heal1;

    // Defeat overlay
    public GameObject restartLevel;
    public GameObject quitLevel;
    public GameObject menuFade;
    public GameObject gameMenu;
    public GameObject settingsButton;
    public int menuCheck = 0;

    int condition = 1; // 0 when round over
    int turn = 1;

    public int prevNum = 0;
    public int numCardsPlayed = 0;
    public int firstNum = 0;

    // Player health
    public double maxHealth = 300;
    public double currentHealth = 300;
    //public int currenthealth = GlobalControl.Instance.HP;
    public Image healthBar;

    // Enemy Health
    public double enemyMaxHealth = 300;
    public double enemyCurrentHealth = 300;
    public Image enemyHealthBar;

    // Cards played
    double damageToTake;
    // public int[] values = new int[3];
    public double card1;
    public double card2;
    public double card3;

    public GameObject cardBlocker;

    //Starts Player's turn
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

    // Function to deal damage to player
    public void TakeDamage(double damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        Debug.Log("Current Health: " + currentHealth);
    }

    // Function to deal damage to enemy
    public void DealDamage(double damageAmount)
    {
        Debug.Log("Damage Dealt");
        enemyCurrentHealth -= damageAmount;
        enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
    }

    // Function to choose card from hand and save value
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
// int effect = card1 + card2 + card3
        if(spots.CardCount >= 3)
        {
            Debug.Log("Deal Card Damage!");

            cardBlocker.SetActive(true);
            
            StartCoroutine(DamageStep());

            yield return new WaitForSeconds(0.5f);

            /*if(enemyCurrentHealth >= 0)
            {
                Debug.Log("Enemy Health: " + enemyCurrentHealth);
                StartCoroutine(EnemyTurn());
                yield return new WaitForSeconds(0.5f);
            }*/
        }
    }

    public IEnumerator DamageStep()
    {
        if(card1 == 21 || card1 == 24 || card1 == 27 || card1 == 30) // heal cards
        {
            DealDamage(card1);
            damage1.text = "-" + (int)card1;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2);
            damage2.text = "-" + (int)card2;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3);
            damage3.text = "-" + (int)card3;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";

            Debug.Log("HEAL!!!!!!!!");
            currentHealth = currentHealth + ((card1 + card2 + card3) * 0.5);
            Debug.Log("CHECKING OUR HEALTH AFTER HEALING RIGHT HERE: " + currentHealth);
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            heal1.text = "+" + (int)((card1 + card2 + card3) * 0.5);
            yield return new WaitForSeconds(0.5f);
        }
        else if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31) // block cards
        {
            DealDamage(card1);
            damage1.text = "-" + (int)card1;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2);
            damage2.text = "-" + (int)card2;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3);
            damage3.text = "-" + (int)card3;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
        }
        else // damage cards
        {
            DealDamage(card1 * 1.25);
            damage1.text = "-" + (int)(card1 * 1.25);
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2 * 1.25);
            damage2.text = "-" + (int)(card2 * 1.25);
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3 * 1.25);
            damage3.text = "-" + (int)(card3 * 1.25);
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
        }

        /*DealDamage(card1);
        yield return new WaitForSeconds(0.5f);
        DealDamage(card2);
        yield return new WaitForSeconds(0.5f);
        DealDamage(card3);
        yield return new WaitForSeconds(0.5f);*/

        StartCoroutine(EnemyCurrentHealthCheck());
    }

    public IEnumerator EnemyCurrentHealthCheck()
    {
        if(enemyCurrentHealth >= 0)
        {
            Debug.Log("Enemy Health: " + enemyCurrentHealth);
            StartCoroutine(EnemyTurn());
            yield return new WaitForSeconds(0.5f);
            heal1.text = "";
        }
    }

    // Function for enemy to take turn
    IEnumerator EnemyTurn(/*int index card 1*/)
    {
        if(condition == 1)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Opponent's turn");
            playerTurnText.text = "OPPONENT'S TURN";
            // make OnMouseDown for cards false
            yield return new WaitForSeconds(1f);
            for(int i = 0; i < 3; i++)
            {
                damageToTake = UnityEngine.Random.Range(25, 45);

                if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31)
                {
                    damageToTake = damageToTake * 0.5;
                }

                TakeDamage(damageToTake);
                if(i == 0)
                {
                    playerDamage1.text = "-" + damageToTake;
                }
                else if(i ==1)
                {
                    playerDamage2.text = "-" + damageToTake;
                }
                else
                {
                    playerDamage3.text = "-" + damageToTake;
                }

                yield return new WaitForSeconds(0.5f);
                playerDamage1.text = "";
                playerDamage2.text = "";
                playerDamage3.text = "";
            }
            yield return new WaitForSeconds(1f);
            StartTurn();
        }
    }

    // Function to remove card from hand
    public void RemoveCard(int index)
    {
        player.Push(spots.Pop(index));
    }

    // Function when victory condition met
    IEnumerator Victory()
    {
        if(condition == 1)
        {
            // GlobalControl.Instance.HP = currenthealth;
            winnerText.text = "VICTORY!!!"; // return to map scene with current progress
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene(sceneName: "Travel Scene");
        }
    }

    // Function when defeat condition met
    IEnumerator Defeat()
    {
        if(condition == 1)
        {
            winnerText.text = "DEFEAT!!!"; // return to start of level (probably some sort of menu tbh)
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            restartLevel.SetActive(true);
            quitLevel.SetActive(true);
            menuFade.SetActive(true);
            gameMenu.SetActive(true);
            //SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    void Start()
    {
        StartCoroutine(StartGame());
        damage1.text = "";
        damage2.text = "";
        damage3.text = "";
        playerDamage1.text = "";
        playerDamage2.text = "";
        playerDamage3.text = "";
        heal1.text = "";
    }

    void Update() //Check if enemy hp <= 0
    {
        if(enemyCurrentHealth <= 0)
        {
            StartCoroutine(Victory());
        }

        if(currentHealth <= 0)
        {
            StartCoroutine(Defeat());
        }

        if (Input.GetKeyDown("escape"))
        {
            menuCheck++;
            if(menuCheck % 2 == 1)
            {
                restartLevel.SetActive(true);
                quitLevel.SetActive(true);
                menuFade.SetActive(true);
                gameMenu.SetActive(true);
                settingsButton.SetActive(true);
            }
            else
            {
                restartLevel.SetActive(false);
                quitLevel.SetActive(false);
                menuFade.SetActive(false);
                gameMenu.SetActive(false);
                settingsButton.SetActive(false);
            }
        }
    }

    IEnumerator StartGame()
    {
        restartLevel.SetActive(false);
        quitLevel.SetActive(false);
        menuFade.SetActive(false);
        gameMenu.SetActive(false);
        settingsButton.SetActive(false);
        cardBlocker.SetActive(false);
        menuCheck = 0;
        turnText.text = "TURN " + turn;
        turn++;
        playerTurnText.text = "YOUR TURN";
        condition = 1;
        for(int i = 0; i < 7; i++)
        {
            player.Push(dealer.Pop(0));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
