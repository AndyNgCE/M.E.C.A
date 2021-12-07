using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanternTracker : MonoBehaviour
{
    Count total;

    public Text lanternText;

    // Start is called before the first frame update
    void Awake()
    {
        total = FindObjectOfType<Count>();
    }

    // Update is called once per frame
    void Update()
    {
        lanternText.text = "" + total.Inventory();
    }
}
