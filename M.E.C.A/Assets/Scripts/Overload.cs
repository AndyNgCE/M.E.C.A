using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overload : MonoBehaviour
{
    PlayerMovement MC;
    Overload many;
    public GameObject clear;
    // Start is called before the first frame update
    void Start()
    {
        MC = FindObjectOfType<PlayerMovement>(); 
        if(MC.flares == 10)
        {
            if (clear == null)
            {
                clear = GameObject.FindGameObjectWithTag("mark");
            }
            MC.flares--;
            Destroy(clear);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "CombatScene" || currentScene.name == "CombatSceneHeal" || currentScene.name == "CombatSceneBlock")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
