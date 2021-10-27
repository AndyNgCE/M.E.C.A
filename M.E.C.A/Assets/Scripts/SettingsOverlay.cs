using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOverlay : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.SetActive(false);
        musicSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
