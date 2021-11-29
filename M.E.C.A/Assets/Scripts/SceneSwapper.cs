using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    PositionSaver playerPosData;
    
    [SerializeField]
    string destination;
    private int destruction;

    public float timeRemaining = 10;
    void Start()
    {
        //Set the tag of this GameObject to Enemy for patrollers
        gameObject.tag = "Enemy";
        playerPosData = FindObjectOfType<PositionSaver>();
        destruction = 1;
    }

    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if(timeRemaining <= 0)
        {
            destruction = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player") && destruction == 0)
        {
            Debug.Log("Triggered by Player");
            // used to put the player back after victory
            playerPosData.playerPosSave();
            SceneManager.LoadScene(sceneName: destination);
        }
        if (col.gameObject.tag.Equals("Player") && destruction == 1)
        {
         Destroy(gameObject);
        }

    }
}
