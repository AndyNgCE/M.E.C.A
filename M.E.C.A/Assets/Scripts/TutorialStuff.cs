using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialStuff : MonoBehaviour
{
    public Text tutorialText;

    public GameObject damageHighlight;
    public GameObject healHighlight;
    public GameObject blockHighlight;
    public GameObject handHighlight;
    public GameObject tutorialBackground;

    public int counter = 0;

    void Start()
    {
        tutorialText.text = "Welcome to M.E.C.A's card combat system!";
        damageHighlight.SetActive(false);
        healHighlight.SetActive(false);
        blockHighlight.SetActive(false);
        handHighlight.SetActive(false);
        StartCoroutine(WaitForCards());
    }

    IEnumerator WaitForCards() // Instead of doing this, just check if we're in the tutorial scene in the gamecontroller and instantly deal out the cards
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }

    void Update()
    {
        if(counter == 1)
        {
            tutorialText.text = "To defeat an enemy, you must lower their HP to 0.";
        }
        else if(counter == 2)
        {
            tutorialText.text = "To do so, you must select 3 cards during a series of turns.";
        }
        else if(counter == 3)
        {
            tutorialText.text = "There are 3 types of cards:";
        }
        else if(counter == 4)
        {
            tutorialText.text = "Damage cards,";
            damageHighlight.SetActive(true);
        }
        else if(counter == 5)
        {
            damageHighlight.SetActive(false);
            tutorialText.text = "Heal cards,";
            healHighlight.SetActive(true);
        }
        else if(counter == 6)
        {
            healHighlight.SetActive(false);
            tutorialText.text = "and Block cards";
            blockHighlight.SetActive(true);
        }
        else if(counter == 7)
        {
            blockHighlight.SetActive(false);
            tutorialText.text = "The number on the card determines the amount of damage the card is going to do.";
        }
        else if(counter == 8)
        {
            tutorialText.text = "You will recieve a random mix of damage, heal, and block cards in your hand below.";
            handHighlight.SetActive(true);
        }
        else if(counter == 9)
        {
            handHighlight.SetActive(false);
            tutorialText.text = "In order to take your turn, you must select 3 cards from your hand to attack with.";
        }
        else if(counter == 10)
        {
            tutorialText.text = "The first card you select determines what kind of attack you make.";
        }
        else if(counter == 11)
        {
            tutorialText.text = "This will either be a bonus to the amount of damage dealt,";
        }
        else if(counter == 12)
        {
            tutorialText.text = "a heal based on the amount of damage dealt,";
        }
        else if(counter == 13)
        {
            tutorialText.text = "or a block which reduces incoming damage that turn.";
        }
        else if(counter == 14)
        {
            tutorialText.text = "Go ahead and select 3 cards and try it out.";
        }
        else if(counter == 15)
        {
            tutorialBackground.SetActive(false);
            tutorialText.text = "";
            Time.timeScale = 1;
        }
    }

    public void IncrementCount()
    {
        counter++;
    }
}
