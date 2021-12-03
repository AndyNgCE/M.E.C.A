using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    /*PositionSaver playerPosData;

    void Start()
    {
       playerPosData = FindObjectOfType<PositionSaver>();
    }*/
    GameObject group;
    private Kill revive;
    private List<int> reload;

    public void QuitGame()
    {
        Debug.Log("QUIT");
        group = GameObject.Find("Reaper");
        revive = group.GetComponent<Kill>();
        reload = revive.GetList();
        foreach (var x in reload)
        {
            Debug.Log("In Grave: " + x.ToString());
        }
        reload.Clear();
        //Application.Quit();
        //playerPosData.playerPosSave();
        SceneManager.LoadScene(sceneName: "MainMenu");
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName: "CombatScene");
    }
}
