using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    PositionSaver playerPosData;

    void Start()
    {
       playerPosData = FindObjectOfType<PositionSaver>();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        playerPosData.playerPosSave();
        SceneManager.LoadScene(sceneName: "MainMenu");
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName: "CombatScene");
    }
}
