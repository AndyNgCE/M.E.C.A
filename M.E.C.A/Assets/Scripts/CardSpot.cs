using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSpot : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    
    public GameObject card;
    public CardBlueprint cardBlueprint;
    
    private Renderer rend;
    private Color startColor;

    CardManager cardManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        cardManager = CardManager.instance;
    }

    public Vector3 GetUsePosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        PlaceCard(cardManager.GetCardToUse());
    }

    void PlaceCard(CardBlueprint blueprint)
    {
        GameObject _card = (GameObject)Instantiate(blueprint.prefab, GetUsePosition(), Quaternion.identity);
        card = _card;

        cardBlueprint = blueprint;

        Debug.Log("Card Placed!");
    }

    void OnMouseEnter() // possibly implement making previously used cards grayed out?
    {
        rend.material.color = hoverColor;

        return;
    }

    void OnMouseExit() // second part of above implementation
    {
        rend.material.color = startColor;

        return;
    }
}
