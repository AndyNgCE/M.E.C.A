using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    PositionSaver playerPosData;

    void Start()
    {
        //Set the tag of this GameObject to Enemy for patrollers
        gameObject.tag = "Enemy";
        playerPosData = FindObjectOfType<PositionSaver>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            // used to put the player back after victory
            playerPosData.playerPosSave();
            SceneManager.LoadScene(sceneName: "CombatScene");
        }
    }
}
