using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{

    // Base health of player starts at 300. This valuse should change between battles
    [SerializeField]
    public int HP;
    public static GlobalControl removal;
    void Awake()
    {
        if (removal != null && removal != this)
        {
            Destroy(this.gameObject);
            return;
        }

        removal = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        HP = PlayerPrefs.GetInt("health");
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }

    public void HealthSave(int healthAmount)
    {
        PlayerPrefs.SetInt("health", healthAmount);
    }

    public int Memory()
    {
        return HP;
    }

}