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
        storyText.text = "This is Command, respond agent...";
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter <= 14)
        {
            Time.timeScale = 0;
        }
        if(counter == 0)
        {
            storyText.text = "Good, you managed to arrive at the city safely...";
        }
        else if(counter == 1)
        {
            storyText.text = "We lost contact with the units we sent beforehand to the location shortly before you arrived...";
        }
        else if(counter == 2)
        {
            storyText.text = "We can only assume they were wiped out by whatever force is occupying the city...";
        }
        else if(counter == 3)
        {
            storyText.text = "Their objective, which is now yours agent, is to make sure the seal tomb here does not break...";
        }
        else if(counter == 4)
        {
            storyText.text = "Your equipped with a newly developed M.E.C.A suit that should give you an edge in combat...";
        }
        else if(counter == 5)
        {
            storyText.text = "Unlike pervious models that could only take one battery at a time to power their functions...";
        }
        else if(counter == 6)
        {
            storyText.text = "Your's can absorb multiple batteries to enhance you combat prowess...";
        }
        else if(counter == 7)
        {
            storyText.text = "The units sent here had extra batteries along with the cities reserves for power but...";
        }
        else if(counter == 8)
        {
            storyText.text = "Based on scans on the area, it seems they were scattered throughout the AO...";
        }
        else if(counter == 9)
        {
            storyText.text = "You remember what they look like right? They're red canisters just touch them and the suit will handle the rest...";
        }
        else if (counter == 10)
        {
            storyText.text = "This city and its sectors can massive complex; Make sure to use your virtual flare system to mark areas you've been too...";
        }
        else if (counter == 11)
        {
            storyText.text = "*To drop a flare, hit E on your keyboard. Ten flares an exist at a time before the last one is replaced*";
        }
        else if (counter == 12)
        {
            storyText.text = "Once you find the seal, if it is broken, hopefully the energy dampeners we set up at the cities founding will weaken the creature enough for you to defeat it...";
        }
        else if (counter == 13)
        {
            storyText.text = "Its immortal so you can't kill it, but you can knock it out...maybe...whatever the case is place its body back in the tomb...";
        }
        else if (counter == 14)
        {
            storyText.text = "The suit will automatically seal it for you and we can extract you...I heard your the best, prove it agent, Command out";
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
