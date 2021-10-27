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
        SceneManager.LoadScene(sceneName: "Travel Scene");
    }

    public void SettingsMenu()
    {
        volumeSlider.SetActive(true);
        musicSlider.SetActive(true);
        settingsFade.SetActive(true);
    }
}
