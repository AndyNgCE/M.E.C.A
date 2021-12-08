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
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("read") == 0)
        {
            storyText.text = "This is Command, respond agent...";
            Time.timeScale = 0;
            currentScene = SceneManager.GetActiveScene();
         }
    }

    // Update is called once per frame
    void Update()
    {
       // if(PlayerPrefs.GetInt("read") == 0)
          //  {
            if(currentScene.name == "Tutorial - Travel Scene" && PlayerPrefs.GetInt("read") == 0)
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
                    storyText.text = "Their objective, which is now yours too agent, is to make sure the seal tomb here does not break...";
                }
                else if(counter == 4)
                {
                    storyText.text = "Your equipped with an experiemenetal M.E.C.A suit that should give you an edge in combat...";
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
                    storyText.text = "The units sent here also had extra batteries along with the cities reserves for power but...";
                }
                else if(counter == 8)
                {
                    storyText.text = "Based on scans on the area, it seems they were scattered throughout the AO...";
                }
                else if(counter == 9)
                {
                    storyText.text = "You remember what they look like right? They're red canisters, just touch them and the suit will handle the rest...";
                }
                else if (counter == 10)
                {
                    storyText.text = "In case you get lost in the city and its sectors; Make sure to use your virtual flare system to mark areas you've been too...";
                }
                else if (counter == 11)
                {
                    storyText.text = "*To drop a flare, hit E on your keyboard. Ten flares an exist at a time before the oldest one is replaced*";
                }
                else if (counter == 12)
                {
                    storyText.text = "Once you find the seal, if it is broken, defeat the creature using your suit...";
                }
                else if (counter == 13)
                {
                    storyText.text = "Its immortal so you can't kill it, but you can knock it out. Whatever the case is, place its body back in the tomb once you defeat it...";
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
            if (currentScene.name == "5 - Travel Scene" && PlayerPrefs.GetInt("read") == 0)
            {
                if (counter <= 15)
                {
                    Time.timeScale = 0;
                }
                if (counter == 0)
                {
                    storyText.text = "Our scans show you are almost to the city's farming land...";
                }
                else if (counter == 1)
                {
                    storyText.text = "This forest was suppose to ward off any unauthorized entities using leyline magic to shift and change its layout as people walked through it...";
                }
                else if (counter == 2)
                {
                    storyText.text = "However, it seems something has disrupted the leylines it stands to reason that the forest can no longer shift...";
                }
                else if (counter == 3)
                {
                    storyText.text = "At least this makes it easier for you to find your way...";
                }
                else if (counter == 4)
                {
                    storyText.text = "Be advised, we are detecting a few unknown entities in your area, you are authorized to use deadly force if necessary...";
                }
                else if (counter == 5)
                {
                    storyText.text = "Again, if see a battery, we advise collecting them...";
                }
                else if (counter == 6)
                {
                    storyText.text = "We can only assume that the forces that defeated the pervious squads will only get stronger as you get closer to the seal...";
                }
                else if (counter == 7)
                {
                    storyText.text = "Without powering up, you may have to get creative with how you reach the next sector...";
                }
                else if (counter == 8)
                {
                    storyText.text = "That isn't to say you have to eliminate everyone, we are on a time schedule here...";
                }
                else if (counter == 9)
                {
                    storyText.text = "But it would make things easier if you engage an enemy...";
                }
                else if (counter == 10)
                {
                    storyText.text = "After all, we need you alive to fix the seal after all, not dead...";
                }
                else if (counter == 11)
                {
                    storyText.text = "Your suit has an emergency call function should you go critical or passout but, it could be some time before we retrive you...";
                }
                else if (counter == 12)
                {
                    storyText.text = "All other remaining special M.E.C.A agents have been dispatched to other nearby cities to protect other seals and assets...";
                }
                else if (counter == 13)
                {
                    storyText.text = "This is coupled with the fact that scan show that the area was laced with special runic shield that seems to repel any unprepared living creature like a barrier";
                }
                else if (counter == 14)
                {
                    storyText.text = "Automatic systems built into every agents armor was strong enough to allow you all to penatrate the barrier initally but, it seems the enemy fortified it further afterwards...";
                }
                else if (counter == 15)
                {
                    storyText.text = "Now, it seems nothing, living or not, can enter now. Your on your own until we break it, Command out";
                }
                else
                {
                    Time.timeScale = 1;
                    storyContainer.SetActive(false);
                    // hide ui stuff here
                }
            }
            if (currentScene.name == "4 - Travel Scene" && PlayerPrefs.GetInt("read") == 0)
            {
                if (counter <= 9)
                {
                    Time.timeScale = 0;
                }
                if (counter == 0)
                {
                    storyText.text = "Strange, this area was SUPPOSE to be the farming lands...";
                }
                else if (counter == 1)
                {
                    storyText.text = "Yet, its devoid of any living plants except for the grass, also where are all the buildings?...";
                }
                else if (counter == 2)
                {
                    storyText.text = "It also seems the area, or at least the stone walls surrounding the town have warped as well...";
                }
                else if (counter == 3)
                {
                    storyText.text = "We don't have time to investigate, scans show that there is an exit on the other side of this area..";
                }
                else if (counter == 4)
                {
                    storyText.text = "Hopefully, that'll take you to the next sector...";
                }
                else if (counter == 5)
                {
                    storyText.text = "Be mindful, the locals and the city itself used special sealed gates to lock off areas...";
                }
                else if (counter == 6)
                {
                    storyText.text = "You'll need to find the corresponding keys to the gates to open them...";
                }
                else if (counter == 7)
                {
                    storyText.text = "Keep in mind the keys are tied to the leylines of the local area...";
                }
                else if (counter == 8)
                {
                    storyText.text = "Meaning, the next area will have its own set of special keys that you'll need to find...";
                }
                else if (counter == 9)
                {
                    storyText.text = "Good luck. Command out";
                }
                else
                {
                    Time.timeScale = 1;
                    storyContainer.SetActive(false);
                    // hide ui stuff here
                }
            }
            if (currentScene.name == "3 - Travel Scene" && PlayerPrefs.GetInt("read") == 0)
            {
                if (counter <= 8)
                {
                    Time.timeScale = 0;
                }
                if (counter == 0)
                {
                    storyText.text = "It appears we were right...";
                }
                else if (counter == 1)
                {
                    storyText.text = "You've entered the first outer wall of the city...";
                }
                else if (counter == 2)
                {
                    storyText.text = "Scans are becoming more scrambled, probably due to the enemies tampering...";
                }
                else if (counter == 3)
                {
                    storyText.text = "We may lose the ability to keep track of you as a result...";
                }
                else if (counter == 4)
                {
                    storyText.text = "Whatever the case is, you objective stays the same...";
                }
                else if (counter == 5)
                {
                    storyText.text = "Reach the seal, verify it integerity, subdue the sealed creature if you must, and evac...";
                }
                else if (counter == 6)
                {
                    storyText.text = "The creature will try to everything in its power to tempt you to let it go...";
                }
                else if (counter == 7)
                {
                    storyText.text = "Do not listen to it, the creature was sealed by the God of Life, our founder, themselves...";
                }
                else if (counter == 8)
                {
                    storyText.text = "Have faith in them, have faith in us, and do your job well. Command out";
                }
                
                else
                {
                    Time.timeScale = 1;
                    storyContainer.SetActive(false);
                    // hide ui stuff here
                }
            }
            if (currentScene.name == "2 - Travel Scene" && PlayerPrefs.GetInt("read") == 0)
            {
                if (counter <= 14)
                {
                    Time.timeScale = 0;
                }
                if (counter == 0)
                {
                    storyText.text = "You suddenly disappeared when you left the outer wall and reappeared at the inner wall of the city...";
                }
                else if (counter == 1)
                {
                    storyText.text = "It helps that you were able to skip navigating the cityscape but, it is troubling see the warping problem that the city is having...";
                }
                else if (counter == 2)
                {
                    storyText.text = "Perhaps this means the civilans in the city are safe?...";
                }
                else if (counter == 3)
                {
                    storyText.text = "We can only hope as we had no contact from anyone after the distress call...";
                }
                else if (counter == 4)
                {
                    storyText.text = "It also appears that the warp has also messed with your suits uplink and radio systems, we'll probably lose you once you leave the area...";
                }
                else if (counter == 5)
                {
                    storyText.text = "For now, let's focus on actually finding the exit here...";
                }
                else if (counter == 6)
                {
                    storyText.text = "Records indicate that unlike the other sectors, this area was built long ago before the city's founding...";
                }
                else if (counter == 7)
                {
                    storyText.text = "Using special pedistals, one can then teleport to other locations...";
                }
                else if (counter == 8)
                {
                    storyText.text = "But, with the leylines clearly disrupted, most of these pedistals are probably inactive now...";
                }
                else if (counter == 9)
                {
                    storyText.text = "Let's hope that the one leading to the seal is still on...";
                }
                else if (counter == 10)
                {
                    storyText.text = "I'm guessing you haven't figured out the intentions of our enemies by any chance...";
                }
                else if (counter == 11)
                {
                    storyText.text = "Its clear they are making way to the seal too and intend on breaking it...";
                }
                else if (counter == 12)
                {
                    storyText.text = "But everyone knows that this sealed creature only wishes to control humanity...";
                }
                else if (counter == 13)
                {
                    storyText.text = "So sayeth our founder...";
                }
                else if (counter == 14)
                {
                    storyText.text = "Hmmm, if you find anything, radio it in. Command out";
                }
                else
                {
                    Time.timeScale = 1;
                    storyContainer.SetActive(false);
                    // hide ui stuff here
                }
            }
            if (currentScene.name == "Travel Scene" && PlayerPrefs.GetInt("read") == 0)
            {
                if (counter <= 2)
                {
                    Time.timeScale = 0;
                }
                if (counter == 0)
                {
                    storyText.text = "*static* -where *static* -you?...";
                }
                else if (counter == 1)
                {
                    storyText.text = "*static* -hearing this, *static* -penetrated barrier *static* -reinforcments coming...";
                }
                else if (counter == 2)
                {
                    storyText.text = "*static* -remember *static* -mission *feed dies*";
                }
                else
                {
                    Time.timeScale = 1;
                    storyContainer.SetActive(false);
                    // hide ui stuff here
                }
            }
       // PlayerPrefs.SetInt("read", 1);
       // }
    }

    public void IncrementCount()
    {
        counter++;
    }
}
