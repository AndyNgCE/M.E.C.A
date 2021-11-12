using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    PositionSaver playerPosData;

    /*void start()
    {
       playerPosData = FindObjectOfType<PositionSaver>();
    }*/

    public void QuitGame()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        //playerPosData.playerPosSave();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName: "CombatScene");
    }
}
