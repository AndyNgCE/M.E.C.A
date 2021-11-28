using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl
{

    // Base health of player starts at 300. This valuse should change between battles
    public int HP = 300;
    /*private void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            HP = PlayerPrefs.GetInt("HP");
            PlayerPrefs.Save();
        }
    }

    public void playerHPSave()
    {
     //Save the current health
    PlayerPrefs.SetInt("HP", GameController.currentHealth);
    PlayerPrefs.SetInt("Saved", 1);
     PlayerPrefs.Save();
    }

public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
    */
    //Want to keep the variable alive through combat and menu scene swap
}