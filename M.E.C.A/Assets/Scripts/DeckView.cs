using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckModel))]
public class DeckView : MonoBehaviour  //CardStackView
{
    //HealthController healthController;
    DeckModel deck;
    Dictionary<int, CardView> fetchedCards;
    int lastCount;
    
    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;

    //int counter = 0;

    public void Clear()
    {
        deck.Reset();

        foreach(CardView view in fetchedCards.Values)
        {
            Destroy(view.Card);
        }

        fetchedCards.Clear();
    }

    void Start()
    {
        fetchedCards = new Dictionary<int, CardView>();
        deck = GetComponent<DeckModel>();
        ShowCards();
        lastCount = deck.CardCount;

        deck.CardRemoved += deck_CardRemoved;
    }

    void deck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if(fetchedCards.ContainsKey(e.CardIndex))
        {
            Destroy(fetchedCards[e.CardIndex].Card);
            fetchedCards.Remove(e.CardIndex);
        }
    }

    void Update()
    {
        if(lastCount != deck.CardCount)
        {
            lastCount = deck.CardCount;
            ShowCards();
        }
    }

    void ShowCards()
    {
        int cardCount = 0;

        if(deck.HasCards)
        {
            foreach(int i in deck.GetCards())
            {
                float co = cardOffset * cardCount;

                Vector3 temp = start + new Vector3(co, 0f);

                AddCard(temp, i, cardCount);

                cardCount++;
            }
        }
    }

    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        if(fetchedCards.ContainsKey(cardIndex))
        {
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ViewCard();

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionalIndex;

        fetchedCards.Add(cardIndex, new CardView(cardCopy));

        //Debug.Log("Hand Value = " + deck.HandValue());
        /*int damageToDeal = deck.HandValue();
        counter++;

        if(counter == 3)
        {
            healthController.DealDamage(damageToDeal);
            counter = 0;
        }*/
    }
}
