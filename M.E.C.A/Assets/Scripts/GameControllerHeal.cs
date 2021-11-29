using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerHeal : MonoBehaviour
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
    public Text heal2;

    // DefeatHeal overlay
    public GameObject restartLevel;
    public GameObject quitLevel;
    public GameObject menuFade;
    public GameObject gameMenu;
    public GameObject settingsButton;

    string fromScene;
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
    public double enemyHealthMark;

    // Cards played
    double damageToTake;
    // public int[] values = new int[3];
    public double card1;
    public double card2;
    public double card3;

    public double healCount = 0;
    public double blockCount = 0;
    public double damageCount = 0;

    public double healMultiplier = 0.5;
    public double blockMultiplier = 0.3;
    public double damageMultiplier = 1.25;

    public double damageCumulative = 0;

    public GameObject cardBlocker;

    //Starts Player's turn
    public void StartTurnHeal()
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

        StartCoroutine(StartGameHeal());
    }

    // Function to deal damage to player
    public void TakeDamageHeal(double damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        Debug.Log("Current Health: " + currentHealth);
    }

    // Function to deal damage to enemy
    public void DealDamageHeal(double damageAmount)
    {
        Debug.Log("Damage Dealt");
        /*if(enemyCurrentHealth > 130 && enemyCurrentHealth < 180) // if enemy health 130 < x < 180
        {
            damageAmount = damageAmount * 0.8;
        }*/
        enemyCurrentHealth -= damageAmount;
        enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
    }

    // Function to choose card from hand and save value
    public IEnumerator ChooseCardHeal(int index)
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
            
            StartCoroutine(DamageStepHeal());

            yield return new WaitForSeconds(0.5f);

            /*if(enemyCurrentHealth >= 0)
            {
                Debug.Log("Enemy Health: " + enemyCurrentHealth);
                StartCoroutine(EnemyTurnHeal());
                yield return new WaitForSeconds(0.5f);
            }*/
        }
    }

    public IEnumerator DamageStepHeal()
    {
        enemyHealthMark = enemyCurrentHealth;

        if(card1 == 21 || card1 == 24 || card1 == 27 || card1 == 30) // heal cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1 = card1 * 0.8;
                card2 = card2 * 0.8;
                card3 = card3 * 0.8;
            }
            DealDamageHeal(card1);
            damage1.text = "-" + (int)card1;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamageHeal(card2);
            damage2.text = "-" + (int)card2;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamageHeal(card3);
            damage3.text = "-" + (int)card3;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";

            Debug.Log("HEAL!!!!!!!!");
            currentHealth = currentHealth + ((card1 + card2 + card3) * healMultiplier);
            Debug.Log("CHECKING OUR HEALTH AFTER HEALING RIGHT HERE: " + currentHealth);
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            heal1.text = "+" + (int)((card1 + card2 + card3) * healMultiplier);
            yield return new WaitForSeconds(0.5f);
        }
        else if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31) // block cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1 = card1 * 0.8;
                card2 = card2 * 0.8;
                card3 = card3 * 0.8;
            }
            DealDamageHeal(card1);
            damage1.text = "-" + (int)card1;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamageHeal(card2);
            damage2.text = "-" + (int)card2;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamageHeal(card3);
            damage3.text = "-" + (int)card3;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
        }
        else // damage cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1 = card1 * 0.8;
                card2 = card2 * 0.8;
                card3 = card3 * 0.8;
            }
            DealDamageHeal(card1 * damageMultiplier);
            damage1.text = "-" + (int)(card1 * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamageHeal(card2 * damageMultiplier);
            damage2.text = "-" + (int)(card2 * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamageHeal(card3 * damageMultiplier);
            damage3.text = "-" + (int)(card3 * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
        }

        /*DealDamageHeal(card1);
        yield return new WaitForSeconds(0.5f);
        DealDamageHeal(card2);
        yield return new WaitForSeconds(0.5f);
        DealDamageHeal(card3);
        yield return new WaitForSeconds(0.5f);*/

        StartCoroutine(EnemyCurrentHealthCheckHeal());
    }

    public IEnumerator EnemyCurrentHealthCheckHeal()
    {
        if(enemyCurrentHealth >= 0)
        {
            Debug.Log("Enemy Health: " + enemyCurrentHealth);
            StartCoroutine(EnemyTurnHeal());
            yield return new WaitForSeconds(0.5f);
            heal1.text = "";
        }
    }

    // Function for enemy to take turn
    IEnumerator EnemyTurnHeal(/*int index card 1*/)
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
                    damageToTake = damageToTake * blockMultiplier;
                }

                if(enemyHealthMark >= 180)
                {
                    damageToTake = damageToTake * 1.1;
                }
                TakeDamageHeal(damageToTake);

                damageCumulative = damageCumulative + damageToTake;

                if(i == 0)
                {
                    playerDamage1.text = "-" + damageToTake;
                }
                else if(i == 1)
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

            if(enemyHealthMark <= 130)
            {
                enemyCurrentHealth = enemyCurrentHealth + (damageCumulative * 0.3);
                heal2.text = "+" + (damageCumulative * 0.3);
                enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
            }

            damageCumulative = 0;
            yield return new WaitForSeconds(1f);

            heal2.text = "";

            // regenerates health
            if(true)
            {
                enemyCurrentHealth += 10;
                enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
                heal2.text = "+10";
                yield return new WaitForSeconds(1f);
                heal2.text = "";
            }

            StartTurnHeal();
        }
    }

    // Function to remove card from hand
    public void RemoveCardHeal(int index)
    {
        player.Push(spots.Pop(index));
    }

    // Function when VictoryHeal condition met
    IEnumerator VictoryHeal()
    {
        if(condition == 1)
        {
            // GlobalControl.Instance.HP = currenthealth;
            winnerText.text = "VictoryHeal!!!"; // return to map scene with current progress
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene(sceneName: "Travel Scene");
        }
    }

    // Function when DefeatHeal condition met
    IEnumerator DefeatHeal()
    {
        if(condition == 1)
        {
            winnerText.text = "DefeatHeal!!!"; // return to start of level (probably some sort of menu tbh)
            condition = 0;
            yield return new WaitForSeconds(3.5f);
            restartLevel.SetActive(true);
            quitLevel.SetActive(true);
            menuFade.SetActive(true);
            gameMenu.SetActive(true);
            //SceneManager.LoadScene(sceneName: "MainMenuHeal");
        }
    }

    public void MainMenuHeal()
    {
        SceneManager.LoadScene(sceneName: "MainMenuHeal");
    }

    public void RestartLevelHeal()
    {
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    void Start()
    {
        fromScene = PlayerPrefs.GetString("p_Scene");
        StartCoroutine(StartGameHeal());
        damage1.text = "";
        damage2.text = "";
        damage3.text = "";
        playerDamage1.text = "";
        playerDamage2.text = "";
        playerDamage3.text = "";
        heal1.text = "";
        heal2.text = "";
    }

    void Update() //Check if enemy hp <= 0
    {
        if(enemyCurrentHealth <= 0)
        {
            StartCoroutine(VictoryHeal());
        }

        if(currentHealth <= 0)
        {
            StartCoroutine(DefeatHeal());
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

    IEnumerator StartGameHeal()
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
        for(int i = 0; i < 5; i++)
        {
            player.Push(dealer.Pop(0));
            yield return new WaitForSeconds(0.1f);
        }
    }
}