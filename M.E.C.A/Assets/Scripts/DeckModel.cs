using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour //CardStack
{
    public List<int> cards;

    public bool isGameDeck;

    public CardModel cardModel;
    public GameController gameController;

    //int numCard = 0;

    public bool HasCards
    {
        get { return cards != null && cards.Count > 0; }
    }

    public event CardRemovedEventHandler CardRemoved;

    public int CardCount
    {
        get
        {
            if(cards == null)
            {
                return 0;
            }
            else
            {
                return cards.Count;
            }
        }
    }

    public IEnumerable<int> GetCards()
    {
        foreach(int i in cards)
        {
            yield return i;
        }
    }

    public int Pop(int index) //default index to 0
    {
        int temp = cards[index];
        cards.RemoveAt(index);

        if(CardRemoved != null)
        {
            CardRemoved(this, new CardRemovedEventArgs(temp));
        }

        return temp;
    }

    public void Push(int card)
    {
        cards.Add(card);
        //cardModel.cardNum = numCard; // set equal to spot index
        //numCard++;
    }

    public int HandValue()
    {
        int total = 0;

        foreach(int card in GetCards())
        {
            int cardVal = card % 13;

            cardVal += 2;

            total = total + cardVal;
        }

        return total;
    }

    public void CreateDeck()
    {
        cards.Clear();

        for(int i = 0; i < 13; i++)
        {
            cards.Add(i);
        }

        int n = cards.Count;
        while(n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }
    
    void Awake()
    {
        cards = new List<int>();
        if(isGameDeck)
        {
            CreateDeck();
        }
    }
}
