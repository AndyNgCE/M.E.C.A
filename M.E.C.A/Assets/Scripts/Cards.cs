using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public CardBlueprint cardOne;

    public CardBlueprint cardTwo;

    public CardBlueprint cardThree;

    public CardBlueprint cardFour;

    public CardBlueprint cardFive;

    public CardBlueprint cardSix;

    public CardBlueprint cardSeven;

    CardManager cardManager;

    void Start()
    {
        cardManager = CardManager.instance;
    }

    public void SelectCardOne()
    {
        Debug.Log("CardOne Selected");
        cardManager.SelectCardToUse(cardOne);
    }

    public void SelectCardTwo()
    {
        Debug.Log("CardTwo Selected");
        cardManager.SelectCardToUse(cardTwo);
    }

    public void SelectCardThree()
    {
        Debug.Log("CardThree Selected");
        cardManager.SelectCardToUse(cardThree);
    }

    public void SelectCardFour()
    {
        Debug.Log("CardFour Selected");
        cardManager.SelectCardToUse(cardFour);
    }

    public void SelectCardFive()
    {
        Debug.Log("CardFive Selected");
        cardManager.SelectCardToUse(cardFive);
    }

    public void SelectCardSix()
    {
        Debug.Log("CardSix Selected");
        cardManager.SelectCardToUse(cardSix);
    }

    public void SelectCardSeven()
    {
        Debug.Log("CardSeven Selected");
        cardManager.SelectCardToUse(cardSeven);
    }
}
