using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour //CardStack
{
    public List<int> cards;

    public bool isGameDeck;

    public CardModel cardModel;
    public GameController gameController;

    public int numCard = 0;

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
        cardModel.cardNum = numCard; // set equal to spot index
        numCard++;
        cards.Add(card);
    }

    public int HandValue()
    {
        int total = 0;

        foreach(int card in GetCards())
        {
            int cardVal = card % 13;

            cardVal += 2;

            if(cardVal == 2)
            {
                cardVal = 20;
            }
            else if(cardVal == 3)
            {
                cardVal = 21;
            }
            else if(cardVal == 4)
            {
                cardVal = 22;
            }
            else if(cardVal == 5)
            {
                cardVal = 23;
            }
            else if(cardVal == 6)
            {
                cardVal = 24;
            }
            else if(cardVal == 7)
            {
                cardVal = 25;
            }
            else if(cardVal == 8)
            {
                cardVal = 26;
            }
            else if(cardVal == 9)
            {
                cardVal = 27;
            }
            else if(cardVal == 10)
            {
                cardVal = 28;
            }
            else if(cardVal == 11)
            {
                cardVal = 29;
            }
            else if(cardVal == 12)
            {
                cardVal = 30;
            }
            else if(cardVal == 13)
            {
                cardVal = 31;
            }
            else if(cardVal == 14)
            {
                cardVal = 32;
            }

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

    public void Reset()
    {
        cards.Clear();
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
