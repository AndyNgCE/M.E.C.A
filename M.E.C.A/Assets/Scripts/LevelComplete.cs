using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField]
    string nextLevel;
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Finish";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            if(nextLevel != null)
            {
                SceneManager.LoadScene(sceneName: nextLevel);
            }
            else
            {
                SceneManager.LoadScene(sceneName: "MainMenu");
            }
        }
    }
}
