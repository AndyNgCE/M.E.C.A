using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] faces;

    public int cardIndex;

    public int cardNum;

    public void ViewCard()
    {
        spriteRenderer.sprite = faces[cardIndex];
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
