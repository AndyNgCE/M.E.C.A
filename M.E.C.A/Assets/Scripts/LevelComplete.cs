using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    Count total;
    public GameObject group;
    private Kill revive;
    private List<int> reload;

    [SerializeField]
    string nextLevel;
    void Start()
    {
        //Set the tag of this GameObject to Player
        revive = group.GetComponent<Kill>();
        reload = revive.GetList();
        gameObject.tag = "Finish";
        reload.Clear();
        total = FindObjectOfType<Count>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            if(nextLevel != null)
            {
                PlayerPrefs.DeleteKey("p_x");
                PlayerPrefs.DeleteKey("p_y");
                PlayerPrefs.DeleteKey("TimetoLoad");
                PlayerPrefs.DeleteKey("Saved");
                total.CollectSave();
                SceneManager.LoadScene(sceneName: nextLevel);
            }
            else
            {
                PlayerPrefs.DeleteKey("p_x");
                PlayerPrefs.DeleteKey("p_y");
                SceneManager.LoadScene(sceneName: "MainMenu");
            }
        }
    }
}
