using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject group;
    private Kill revive;
    private List<int> reload;
    // The deck, player's hand, and cards chosen
    public DeckModel player;
    public DeckModel dealer;
    public DeckModel spots;
    //public DeckModel deckModel;

    Count total;
    GlobalControl gControl;

    Scene currentScene;

    //public HealthController healthController;
    
    // UI text
    public Text winnerText;
    public Text turnText;
    public Text playerTurnText;

    public Text playerHP;
    public Text enemyHP;

    public Text damage1;
    public Text damage2;
    public Text damage3;

    public Text playerDamage1;
    public Text playerDamage2;
    public Text playerDamage3;

    public Text heal1;
    public Text heal2;

    public Text damageIconNum;
    public Text healIconNum;
    public Text blockIconNum;

    // Defeat overlay
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
    public double currentHealth;
    //public int currenthealth = GlobalControl.Instance.HP;
    public Image healthBar;

    // Enemy Health
    public double enemyMaxHealth = 600;
    public double enemyCurrentHealth = 600;
    public Image enemyHealthBar;
    public double enemyHealthMark;

    // Cards played
    double damageToTake;
    // public int[] values = new int[3];
    public double card1;
    public double card2;
    public double card3;

    public double card1block;
    public double card2block;
    public double card3block;

    public double healCount = 0;
    public double blockCount = 0;
    public double damageCount = 0;
    public double blockCountText = 0;

    public double healMultiplier = 0.5;
    public double blockMultiplier = 0.3;
    public double damageMultiplier = 1.25;

    public double damageCumulative = 0;

    public GameObject cardBlocker;

    public int enemyCheck;

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
        currentHealth -= (int)damageAmount;
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        playerHP.text = currentHealth + " / " + maxHealth;
        Debug.Log("Current Health: " + currentHealth);
    }

    // Function to deal damage to enemy
    public void DealDamage(double damageAmount)
    {
        Debug.Log("Damage Dealt");
        enemyCurrentHealth -= (int)damageAmount;
        enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
        enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;
    }

    // Function to choose card from hand and save value
    public IEnumerator ChooseCard(int index)
    {
        spots.Push(player.Pop(index));  // 0 needs to be the card's index

        if(spots.CardCount == 1)
        {
            card1 = spots.HandValue();
            card1block = spots.HandValue();
        }
        else if(spots.CardCount == 2)
        {
            card2 = spots.HandValue() - card1;
            card2block = spots.HandValue() - card1;
        }
        else
        {
            card3 = spots.HandValue() - card1 - card2;
            card3block = spots.HandValue() - card1 - card2;
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
        enemyHealthMark = enemyCurrentHealth;

        if(card1 == 21 || card1 == 24 || card1 == 27 || card1 == 30) // heal cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1block = card1 * 0.8;
                card2block = card2 * 0.8;
                card3block = card3 * 0.8;
            }
            if(enemyCheck == 2 || enemyCheck == 3)
            {
                card1block -= 5;
                card2block -= 5;
                card3block -= 5;
            }
            DealDamage(card1block);
            damage1.text = "-" + (int)card1block;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2block);
            damage2.text = "-" + (int)card2block;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3block);
            damage3.text = "-" + (int)card3block;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";

            Debug.Log("HEAL!!!!!!!!");

            if(healCount == 0)
            {
                healMultiplier = (0.7 + (total.Inventory() * 0.05));
            }
            else if(healCount == 1)
            {
                healMultiplier = (0.35 + (total.Inventory() * 0.05));
            }
            else if(healCount == 2)
            {
                healMultiplier = 0;
            }
            /*else if(healCount == 3)
            {
                healMultiplier = (0.2 + (total.Inventory() * 0.05));
            }
            else if(healCount >= 4)
            {
                healMultiplier = (0.1 + (total.Inventory() * 0.05));
            }*/
            if(enemyCurrentHealth <= 0)
            {
                healMultiplier = 0;
            }
            currentHealth = currentHealth + (int)((card1block + card2block + card3block) * healMultiplier);
            Debug.Log("CHECKING OUR HEALTH AFTER HEALING RIGHT HERE: " + currentHealth);
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            playerHP.text = currentHealth + " / " + maxHealth;
            heal1.text = "+" + (int)((card1block + card2block + card3block) * healMultiplier);
            healCount++;
            if(blockCount != 0)
            {
                blockCount--;
                blockCountText--;
            }

            if(damageCount != 0)
            {
                damageCount--;
            }
            yield return new WaitForSeconds(0.5f);
        }
        else if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31) // block cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1block = card1 * 0.8;
                card2block = card2 * 0.8;
                card3block = card3 * 0.8;
            }
            if(enemyCheck == 2 || enemyCheck == 3)
            {
                card1block -= 5;
                card2block -= 5;
                card3block -= 5;
            }
            DealDamage(card1block);
            damage1.text = "-" + (int)card1block;
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2block);
            damage2.text = "-" + (int)card2block;
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3block);
            damage3.text = "-" + (int)card3block;
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
        }
        else // damage cards
        {
            if(enemyHealthMark > 130 && enemyHealthMark < 180)
            {
                card1block = card1 * 0.8;
                card2block = card2 * 0.8;
                card3block = card3 * 0.8;
            }
            if(enemyCheck == 2 || enemyCheck == 3)
            {
                card1block -= 5;
                card2block -= 5;
                card3block -= 5;
            }

            if(damageCount == 0)
            {
                damageMultiplier = (1.25 + (total.Inventory() * 0.1));
            }
            else if(damageCount == 1)
            {
                damageMultiplier = (1.125 + (total.Inventory() * 0.1));
            }
            else if(damageCount == 2)
            {
                damageMultiplier = 1;
            }
            /*else if(damageCount == 3)
            {
                damageMultiplier = (1.1 + (total.Inventory() * 0.1));
            }
            else if(damageCount >= 4)
            {
                damageMultiplier = (1.05 + (total.Inventory() * 0.1));
            }*/

            DealDamage(card1block * damageMultiplier);
            damage1.text = "-" + (int)(card1block * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage1.text = "";
            DealDamage(card2block * damageMultiplier);
            damage2.text = "-" + (int)(card2block * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage2.text = "";
            DealDamage(card3block * damageMultiplier);
            damage3.text = "-" + (int)(card3block * damageMultiplier);
            yield return new WaitForSeconds(0.5f);
            damage3.text = "";
            damageCount++;
            if(blockCount != 0)
            {
                blockCount--;
                blockCountText--;
            }

            if(healCount != 0)
            {
                healCount--;
            }
        }

        if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31)
        {
            blockCountText++;
        }

        damageIconNum.text = "" + damageCount;
        healIconNum.text = "" + healCount;
        blockIconNum.text = "" + blockCountText;

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
                //damageToTake = UnityEngine.Random.Range(25, 45);
                //damageToTake = 20;
                /*if(1)
                10-20
                if(2)
                12-22
                if(3)
                14-24*/
                if(currentScene.name == "CombatSceneBoss")
                {
                    damageToTake = UnityEngine.Random.Range(40, 45);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "Tutorial - Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(5, 10);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "5 - Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(10, 15);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "4 - Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(15, 20);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "3 - Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(20, 25);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "2 - Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(25, 30);
                }
                else if(PlayerPrefs.GetString("p_Scene") == "Travel Scene")
                {
                    damageToTake = UnityEngine.Random.Range(30, 35);
                }

                if(card1 == 22 || card1 == 25 || card1 == 28 || card1 == 31)
                {
                    if(blockCount == 0)
                    {
                        blockMultiplier = (0.3 + (total.Inventory() * 0.025));
                    }
                    else if(blockCount == 1)
                    {
                        blockMultiplier = (0.15 + (total.Inventory() * 0.025));
                    }
                    else if(blockCount == 2)
                    {
                        blockMultiplier = 0;
                    }
                    /*else if(blockCount == 3)
                    {
                        blockMultiplier = (0.15 + (total.Inventory() * 0.025));
                    }
                    else if(blockCount >= 4)
                    {
                        blockMultiplier = (0.1 + (total.Inventory() * 0.025));
                    }*/

                    damageToTake = (int)(damageToTake * (1 - blockMultiplier));
                    if(i == 2)
                    {
                        blockCount++;
                        if(healCount != 0)
                        {
                            healCount--;
                        }

                        if(damageCount != 0)
                        {
                            damageCount--;
                        }
                        damageIconNum.text = "" + damageCount;
                        healIconNum.text = "" + healCount;
                        blockIconNum.text = "" + blockCountText;
                    }
                }

                if(enemyHealthMark >= 180)
                {
                    damageToTake = damageToTake * 1.1;
                }
                TakeDamage(damageToTake);

                damageCumulative = damageCumulative + (int)damageToTake;

                if(i == 0)
                {
                    playerDamage1.text = "-" + (int)damageToTake;
                }
                else if(i == 1)
                {
                    playerDamage2.text = "-" + (int)damageToTake;
                }
                else
                {
                    playerDamage3.text = "-" + (int)damageToTake;
                }

                yield return new WaitForSeconds(0.5f);
                playerDamage1.text = "";
                playerDamage2.text = "";
                playerDamage3.text = "";
            }

            if(enemyHealthMark <= 130)
            {
                enemyCurrentHealth = enemyCurrentHealth + (int)(damageCumulative * 0.3);
                heal2.text = "+" + (int)(damageCumulative * 0.3);
                enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
                enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;
            }

            damageCumulative = 0;
            yield return new WaitForSeconds(1f);

            heal2.text = "";

            // 5 health damage at end turn
            if(enemyCheck == 0 || enemyCheck == 3)
            {
                currentHealth -= 10;
                healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
                playerHP.text = currentHealth + " / " + maxHealth;
                playerDamage1.text = "-10";
                yield return new WaitForSeconds(1f);
                playerDamage1.text = "";
            }

            if(enemyCheck == 1 || enemyCheck == 3)
            {
                enemyCurrentHealth += 10;
                enemyHealthBar.fillAmount = (float)enemyCurrentHealth / (float)enemyMaxHealth;
                enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;
                heal2.text = "+10";
                yield return new WaitForSeconds(1f);
                heal2.text = "";
            }

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
            //gControl.HealthSave((int)currentHealth);
            gControl.HP = (int)currentHealth;
            yield return new WaitForSeconds(3.5f);
            if(currentScene.name == "CombatSceneBoss")
            {
                SceneManager.LoadScene(sceneName: "BossSceneWin");
            }
            else
            {
                SceneManager.LoadScene(sceneName: PlayerPrefs.GetString("p_Scene"));
            }
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
            if(currentScene.name == "CombatSceneBoss")
            {
                SceneManager.LoadScene(sceneName: "BossSceneLose");
            }
            restartLevel.SetActive(true);
            quitLevel.SetActive(true);
            menuFade.SetActive(true);
            gameMenu.SetActive(true);
            //SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        group = GameObject.Find("Reaper");
        revive = group.GetComponent<Kill>();
        //DestroyImmediate(revive, true);
        reload = revive.GetList();
        reload.Clear();
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimetoLoad");
        PlayerPrefs.DeleteKey("Saved");
        total.collected = PlayerPrefs.GetInt("lamp");
        gControl.HP = 300;
        string walkOfShame = PlayerPrefs.GetString("p_Scene");
        SceneManager.LoadScene(sceneName: walkOfShame);
    }

    void Start()
    {
        fromScene = PlayerPrefs.GetString("p_Scene");

        currentScene = SceneManager.GetActiveScene();

        currentHealth = gControl.Memory();

        //currentHealth = healthController.currentPlayerHealth;
        playerHP.text = currentHealth + " / " + maxHealth;
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;

        healMultiplier = (0.5 + (total.Inventory() * 0.05));
        blockMultiplier = (0.3 + (total.Inventory() * 0.025));
        damageMultiplier = (1.25 + (total.Inventory() * 0.1));

        blockCount = 0;
        healCount = 0;
        damageCount = 0;

        damage1.text = "";
        damage2.text = "";
        damage3.text = "";
        playerDamage1.text = "";
        playerDamage2.text = "";
        playerDamage3.text = "";
        heal1.text = "";
        heal2.text = "";
        StartCoroutine(StartGame());
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
                Time.timeScale = 0;
                restartLevel.SetActive(true);
                quitLevel.SetActive(true);
                menuFade.SetActive(true);
                gameMenu.SetActive(true);
                settingsButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                restartLevel.SetActive(false);
                quitLevel.SetActive(false);
                menuFade.SetActive(false);
                gameMenu.SetActive(false);
                settingsButton.SetActive(false);
            }
        }

        damageIconNum.text = "" + damageCount;
        healIconNum.text = "" + healCount;
        blockIconNum.text = "" + blockCountText;

        if(blockCount > 2)
        {
            blockCount = 2;
            blockCountText = 2;
            blockIconNum.text = "" + blockCountText;
        }

        if(healCount > 2)
        {
            healCount = 2;
            healIconNum.text = "" + healCount;
        }

        if(damageCount > 2)
        {
            damageCount = 2;
            damageIconNum.text = "" + damageCount;
        }

        if(currentHealth < 0)
        {
            currentHealth = 0;
            playerHP.text = currentHealth + " / " + maxHealth;
        }

        if(enemyCurrentHealth < 0)
        {
            enemyCurrentHealth = 0;
            enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;
        }

        if(currentHealth > 300)
        {
            currentHealth = 300;
            playerHP.text = currentHealth + " / " + maxHealth;
        }

        /*if(enemyCurrentHealth > 300)
        {
            enemyCurrentHealth = 300;
            enemyHP.text = enemyCurrentHealth + " / " + enemyMaxHealth;
        }*/
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
        for(int i = 0; i < 5; i++)
        {
            player.Push(dealer.Pop(0));
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Awake()
    {
        total = FindObjectOfType<Count>();
        gControl = FindObjectOfType<GlobalControl>();
    }
}
