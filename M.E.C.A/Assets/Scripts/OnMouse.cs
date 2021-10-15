using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public GameController gameController;

    void OnMouseDown()
    {
        gameController.ChooseCard(0); // Need the 0 in here to be the index of the card in hand(player)
    }
}
