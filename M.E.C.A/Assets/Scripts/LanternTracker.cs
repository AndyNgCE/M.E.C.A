using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanternTracker : MonoBehaviour
{
    Count total;
    GlobalControl gControl;
    GameObject counter;

    public Image healthBar;

    public int counted;

    public Text lanternText;
    public Text healthText;

    // Start is called before the first frame update
    void Awake()
    {
        counter = GameObject.Find("Reaper");
        total = counter.GetComponent<Count>();
        gControl = FindObjectOfType<GlobalControl>();
        counted = total.Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        counted = total.Inventory();
        lanternText.text = "" + total.Inventory();
        healthText.text = gControl.Memory() + " / 300";
        healthBar.fillAmount = (float)gControl.Memory() / 300;
    }
}
