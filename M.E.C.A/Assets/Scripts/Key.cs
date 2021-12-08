using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public bool door1 = false;
    public Sprite newSprite;
    public static Key removal;
    void Start()
    {
           
        if (removal != null && removal != this)
        {
            Destroy(this.gameObject);
            return;
        }

        removal = this;
        DontDestroyOnLoad(this);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            door1 = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "MainMenu")
        {
            Destroy(this);
        }
        if (currentScene.name == "CombatScene" || currentScene.name == "CombatSceneHeal" || currentScene.name == "CombatSceneBlock")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
