using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public DeckModel dealer;
    public DeckModel player;

    void OnGUI()
    {
        if(GUI.Button(new Rect(30, 30, 300, 200), "Hit Me!"))
        {
            player.Push(dealer.Pop());
        }
    }
}
