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
    public GameObject settingsText;
    public GameObject rectangle;
    public GameObject quitButton;

    public GameObject settings;

    public Slider soundBar;
    public Slider musicBar;

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
        PlayerPrefs.DeleteKey("p_scene");
        Debug.Log("PLAY");
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    // For continue option
    public void loadGame()
    {
        // Removes last battle position for true restart of level
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.DeleteKey("TimetoLoad");
        PlayerPrefs.DeleteKey("Saved");
        // Pull last known level played
        string goToScene = PlayerPrefs.GetString("p_Scene");
        SceneManager.LoadScene(sceneName: goToScene);
        Debug.Log(goToScene);
    }


    public void SettingsMenu()
    {
        /*volumeSlider.SetActive(true);
        musicSlider.SetActive(true);
        settingsFade.SetActive(true);
        rectangle.SetActive(true);
        settingsText.SetActive(true);
        quitButton.SetActive(true);*/
        //soundBar.interactable = true;
        settings.SetActive(true);
    }

    public void SettingsMenuClose()
    {
        /*volumeSlider.SetActive(false);
        musicSlider.SetActive(false);
        settingsFade.SetActive(false);
        rectangle.SetActive(false);
        settingsText.SetActive(false);
        quitButton.SetActive(false);*/
        settings.SetActive(false);
    }

    public void MainMenuTravel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void RestartLevelTravel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    void Start()
    {
        /*volumeSlider.SetActive(false);
        musicSlider.SetActive(false);
        settingsFade.SetActive(false);
        rectangle.SetActive(false);
        settingsText.SetActive(false);
        quitButton.SetActive(false);*/
        settings.SetActive(false);
        soundBar.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        musicBar.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    public void ValueChangeCheck()
    {
        Debug.Log(soundBar.value);
        Debug.Log(musicBar.value);
    }
}
