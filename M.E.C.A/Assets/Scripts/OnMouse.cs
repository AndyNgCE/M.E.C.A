using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public GameController gameController;
    public CardModel cardModel;

    public void OnMouseDown()
    {
        if(gameController.numCardsPlayed == 0)
        {
            gameController.firstNum = cardModel.cardNum;
        }
        else if(gameController.numCardsPlayed == 1)
        {
            gameController.prevNum = cardModel.cardNum;
            if(cardModel.cardNum > gameController.firstNum)
            {
                cardModel.cardNum--;
            }
        }
        else if(gameController.numCardsPlayed == 2)
        {
            if(cardModel.cardNum > gameController.firstNum && cardModel.cardNum > gameController.prevNum)
            {
                cardModel.cardNum = cardModel.cardNum - 2;
            }
            else if(cardModel.cardNum > gameController.firstNum && cardModel.cardNum < gameController.prevNum)
            {
                cardModel.cardNum--;
            }
            else if(cardModel.cardNum < gameController.firstNum && cardModel.cardNum > gameController.prevNum)
            {
                cardModel.cardNum--;
            }
        }

        gameController.numCardsPlayed++;
        StartCoroutine(gameController.ChooseCard(cardModel.cardNum)); // Need the 0 in here to be the index of the card in hand(player)
    }
}
