using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // On start of level, save the name of the level so that the continue button will link back to that level.
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("p_Scene", currentScene.name);
        PlayerPrefs.Save();
    }

}
