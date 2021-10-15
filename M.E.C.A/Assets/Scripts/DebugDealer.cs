using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public DeckModel dealer;
    public DeckModel player;
    public DeckModel spots;

    void OnGUI()
    {
        if(GUI.Button(new Rect(30, 30, 300, 200), "Hit Me!"))
        {
            player.Push(spots.Pop(0));
        }

        if(GUI.Button(new Rect(30, 800, 300, 200), "Hit Me!"))
        {
            spots.Push(player.Pop(0));
            //HealthController.TakeDamage(10);
        }
    }
}
