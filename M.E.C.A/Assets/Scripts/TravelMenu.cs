using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelMenu : MonoBehaviour
{
    public GameObject restartLevel;
    public GameObject quitLevel;
    public GameObject menuFade;
    public GameObject gameMenu;
    public GameObject settingsButton;
    public int menuCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        restartLevel.SetActive(false);
        quitLevel.SetActive(false);
        menuFade.SetActive(false);
        gameMenu.SetActive(false);
        settingsButton.SetActive(false);
        menuCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            menuCheck++;
            if(menuCheck % 2 == 1)
            {
                Time.timeScale = 0;
                restartLevel.SetActive(true);
                quitLevel.SetActive(true);
                menuFade.SetActive(true);
                gameMenu.SetActive(true);
                settingsButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                restartLevel.SetActive(false);
                quitLevel.SetActive(false);
                menuFade.SetActive(false);
                gameMenu.SetActive(false);
                settingsButton.SetActive(false);
            }
        }
    }
}
