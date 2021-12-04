using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Count : MonoBehaviour
{
    [SerializeField]
   public int collected = 0;
    public static Count removal;
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
        collected = PlayerPrefs.GetInt("lamp");
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }

   public void AddtoTotal()
    {
        collected++;
    }

    public void CollectSave()
    {
        PlayerPrefs.SetInt("lamp", collected);
    }

    public int Inventory()
    {
        return collected;
    }

}
