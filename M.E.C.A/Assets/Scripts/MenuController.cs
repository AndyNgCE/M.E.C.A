using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject musicSlider;
    public GameObject settingsFade;

    public void Quit()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Play()
    {
        // clears saved data for new games
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.DeleteKey("TimetoLoad");
        PlayerPrefs.DeleteKey("Saved");
        Debug.Log("PLAY");
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    // For continue option
    public void loadGame()
    {
        SceneManager.LoadScene(sceneName: "Travel Scene");
        Debug.Log("LOAD");
    }


    public void SettingsMenu()
    {
        volumeSlider.SetActive(true);
        musicSlider.SetActive(true);
        settingsFade.SetActive(true);
    }
}
