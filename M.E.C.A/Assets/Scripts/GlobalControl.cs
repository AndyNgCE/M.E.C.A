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