using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    void Start()
    {
        //Set the tag of this GameObject to Enemy for patrollers
        gameObject.tag = "Enemy";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            SceneManager.LoadScene(sceneName: "CombatScene");
        }
    }
}
