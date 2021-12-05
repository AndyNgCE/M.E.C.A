using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwapper : MonoBehaviour
{
    PositionSaver playerPosData;
    
    [SerializeField]
    string destination;

   // [SerializeField]
    GameObject indicator;
    private Kill knockOut;
    private List<int> tagline;
    
    [SerializeField]
    int ID;
    SpriteRenderer sprite;
    void Start()
    {
        //Set the tag of this GameObject to Enemy for patrollers
        gameObject.tag = "Enemy";
        playerPosData = FindObjectOfType<PositionSaver>();
        indicator = GameObject.Find("Reaper");
        knockOut = indicator.GetComponent<Kill>();
        tagline = knockOut.GetList();
        sprite = GetComponent<SpriteRenderer>();
        if(destination == "CombatScene")
            sprite.color = new Color(255, 0, 0, 1);
        if(destination == "CombatSceneHeal")
            sprite.color = new Color(0, 255, 0, 1);
        if (destination == "CombatSceneBlock")
            sprite.color = new Color(0, 0, 255, 1);
    }

    void CheckUp()
    {
        if(!tagline.Contains(ID))
        {
            tagline.Add(ID);
            Debug.Log("ADD " + ID);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            // used to put the player back after victory
            playerPosData.playerPosSave();
            CheckUp();
            SceneManager.LoadScene(sceneName: destination);
        }
    }
}
