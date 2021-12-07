using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject musicSlider;
    public GameObject settingsFade;
    public void Quit()
    {
        Debug.Log("QUIT");
        //playerPosData.playerPosSave();
        Application.Quit();
        //SceneManager.LoadScene(sceneName: "MainMenu");
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Play()
    {
        // clears saved data for new games
        Debug.Log("Clearing Keys");
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.DeleteKey("TimetoLoad");
        PlayerPrefs.DeleteKey("Saved");
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }
    public void loadGame()
    {
        Debug.Log("NEVER GONNA GIVE YOU UP");
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }
    public void setting()
    {
        Debug.Log("SET");
    }

    public void SettingsMenu()
    {
        volumeSlider.SetActive(true);
        musicSlider.SetActive(true);
        settingsFade.SetActive(true);
    }
}
