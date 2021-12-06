using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key3 : MonoBehaviour
{
    public bool door3 = false;
 
    public Sprite newSprite;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            door3 = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            Destroy(this);
        }
        if (currentScene.name == "CombatScene" || currentScene.name == "CombatSceneHeal" || currentScene.name == "CombatSceneBlock")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}