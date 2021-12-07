using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnColor : MonoBehaviour
{
    SpriteRenderer sprite;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if(currentScene.name == "CombatScene")
            sprite.color = new Color(255, 0, 0, 1);
        if(currentScene.name == "CombatSceneHeal")
            sprite.color = new Color(0, 255, 0, 1);
        if(currentScene.name == "CombatSceneBlock")
            sprite.color = new Color(0, 0, 255, 1);
    }
}
