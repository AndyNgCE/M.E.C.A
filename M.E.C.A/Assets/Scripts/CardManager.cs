using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 CardManager in scene!");
            return;
        }
        instance = this;
    }

    private CardBlueprint cardToUse;

    private CardSpot selectedSpot;

    public void SelectSpot(CardSpot spot)
    {
        if(selectedSpot == spot)
        {
            DeselectSpot();
            return;
        }

        selectedSpot = spot;
        cardToUse = null;

        //spotUI.SetTarget(spot);
    }

    public void DeselectSpot()
    {
        selectedSpot = null;
        //spotUI.Hide();
    }

    public void SelectCardToUse(CardBlueprint card)
    {
        cardToUse = card;
        DeselectSpot();
    }

    public CardBlueprint GetCardToUse()
    {
        return cardToUse;
    }
}
