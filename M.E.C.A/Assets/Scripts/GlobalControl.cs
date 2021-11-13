using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int HP = 100;
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
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

/*private void Start()
{
    if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
    {
        // Set current player X and Y coordinates
        float pX = player.transform.position.x;
        float pY = player.transform.position.y;

        pX = PlayerPrefs.GetFloat("p_x");
        pY = PlayerPrefs.GetFloat("p_y");
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
    PlayerPrefs.SetInt("Saved", 1);
    PlayerPrefs.Save();
}

public void PlayerPosLoad()
{
    PlayerPrefs.SetInt("TimeToLoad", 1);
    PlayerPrefs.Save();
}*/