using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{
    Scene currentScene;
    Count total;
    GameObject counter;

    public GameObject[] clear;
    public GameObject[] locks;
    public GameObject group;
    private Kill revive;
    private List<int> reload;

    public void SkipLevelFunc()
    {
        total.CollectSave();
        foreach (GameObject locks in locks)
        {
            Destroy(locks.gameObject);
        }
        foreach (GameObject clear in clear)
        {
            Destroy(clear.gameObject);
        }
        reload.Clear();
        if(currentScene.name == "Tutorial - Travel Scene")
        {
            SceneManager.LoadScene(sceneName: "5 - Travel Scene");
        }
        else if(currentScene.name == "5 - Travel Scene")
        {
            SceneManager.LoadScene(sceneName: "4 - Travel Scene");
        }
        else if(currentScene.name == "4 - Travel Scene")
        {
            SceneManager.LoadScene(sceneName: "3 - Travel Scene");
        }
        else if(currentScene.name == "3 - Travel Scene")
        {
            SceneManager.LoadScene(sceneName: "2 - Travel Scene");
        }
        else if(currentScene.name == "2 - Travel Scene")
        {
            SceneManager.LoadScene(sceneName: "Travel Scene");
        }
    }

    public void IncrementLanterns()
    {
        total.AddtoTotal();
    }

    // Start is called before the first frame update
    void Start()
    {
        group = GameObject.Find("Reaper");
        currentScene = SceneManager.GetActiveScene();
        counter = GameObject.Find("Reaper");
        total = counter.GetComponent<Count>();
        revive = group.GetComponent<Kill>();
        reload = revive.GetList();
    }
    void Update()
    {
        locks = GameObject.FindGameObjectsWithTag("lock");
        clear = GameObject.FindGameObjectsWithTag("mark");
    }
}
