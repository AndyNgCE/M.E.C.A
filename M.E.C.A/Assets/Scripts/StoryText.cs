using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    public Text storyText;

    public int counter = 0;

    public GameObject storyContainer;

    // Start is called before the first frame update
    void Start()
    {
        storyText.text = "Whatever you want it to say first.";
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter <= 9)
        {
            Time.timeScale = 0;
        }
        if(counter == 0)
        {
            storyText.text = "Whatever you want it to say first.";
        }
        else if(counter == 1)
        {
            storyText.text = "More words here 1";
        }
        else if(counter == 2)
        {
            storyText.text = "More words here 2";
        }
        else if(counter == 3)
        {
            storyText.text = "More words here 3";
        }
        else if(counter == 4)
        {
            storyText.text = "More words here 4";
        }
        else if(counter == 5)
        {
            storyText.text = "More words here 5";
        }
        else if(counter == 6)
        {
            storyText.text = "More words here 6";
        }
        else if(counter == 7)
        {
            storyText.text = "More words here 7";
        }
        else if(counter == 8)
        {
            storyText.text = "More words here 8";
        }
        else if(counter == 9)
        {
            storyText.text = "More words here 9";
        }
        else
        {
            Time.timeScale = 1;
            storyContainer.SetActive(false);
            // hide ui stuff here
        }
    }

    public void IncrementCount()
    {
        counter++;
    }
}
