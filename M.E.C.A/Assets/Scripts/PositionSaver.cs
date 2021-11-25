using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            // Set current player X and Y coordinates
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            Debug.Log("pX = " + pX);
            Debug.Log("pY = " + pY);
            player.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }
    public void playerPosSave()
    {
        // Save the current X and Y positions of player
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        Debug.Log("Setting floats");
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    // Used to identify when to call in saved data
    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
