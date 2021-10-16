using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Enemy";
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player")
        {
            Debug.Log("Triggered by Player");
            SceneManager.LoadScene(sceneName: "CombatScene");
        }
    }
}
