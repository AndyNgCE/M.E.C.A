using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanternTracker : MonoBehaviour
{
    Count total;
    GlobalControl gControl;
    public Image healthBar;

    public Text lanternText;
    public Text healthText;

    // Start is called before the first frame update
    void Awake()
    {
        total = FindObjectOfType<Count>();
        gControl = FindObjectOfType<GlobalControl>();
    }

    // Update is called once per frame
    void Update()
    {
        lanternText.text = "" + total.Inventory();
        healthText.text = gControl.Memory() + " / 300";
        healthBar.fillAmount = (float)gControl.Memory() / 300;
    }
}
