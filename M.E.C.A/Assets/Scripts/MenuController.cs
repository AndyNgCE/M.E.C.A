using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }
}
