using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    Count total;
    GlobalControl gControl;
    public GameObject group;
    private Kill revive;
    private List<int> reload;
    public GameObject[] clear;
    public GameObject[] locks;
    public GameObject SaveNum;
    PlayerMovement MC;

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
        gControl = FindObjectOfType<GlobalControl>();
    }

    void Update()
    {
        locks = GameObject.FindGameObjectsWithTag("lock");
        clear = GameObject.FindGameObjectsWithTag("mark");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            MC = FindObjectOfType<PlayerMovement>();
            Debug.Log("Triggered by Player");
            if(nextLevel != null)
            {
                PlayerPrefs.DeleteKey("p_x");
                PlayerPrefs.DeleteKey("p_y");
                PlayerPrefs.DeleteKey("TimetoLoad");
                PlayerPrefs.DeleteKey("Saved");
                total.CollectSave();
                gControl.HP = 300;
                if(locks == null)
                {
                    locks = GameObject.FindGameObjectsWithTag("lock");
                }
                foreach (GameObject locks in locks)
                {
                    Destroy(locks.gameObject);
                }
                if (clear == null)
                {
                    clear = GameObject.FindGameObjectsWithTag("mark");
                }
                foreach (GameObject clear in clear)
                {
                    MC.flares--;
                    Destroy(clear.gameObject);
                }
                PlayerPrefs.SetInt("read", 0);
               // SaveNum = GameObject.Find("Reaper");

                //PlayerPrefs.SetInt("lamp", );
                SceneManager.LoadScene(sceneName: nextLevel);
            }
            /*else
            {
                if (clear == null)
                {
                    clear = GameObject.FindGameObjectsWithTag("mark");
                }
                foreach (GameObject clear in clear)
                {
                    MC.flares--;
                    Destroy(clear);
                }
                if (locks == null)
                {
                    locks = GameObject.FindGameObjectsWithTag("lock");
                }
                foreach (GameObject locks in locks)
                {
                    Destroy(locks);
                }
                PlayerPrefs.DeleteKey("p_x");
                PlayerPrefs.DeleteKey("p_y");
                SceneManager.LoadScene(sceneName: "MainMenu");
            }*/
        }
    }
}
