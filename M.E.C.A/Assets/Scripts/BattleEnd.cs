using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public GameObject restartLevel;
    public GameObject quitLevel;
    public GameObject deadText;

    // Start is called before the first frame update
    void Start()
    {
        restartLevel.SetActive(false);
        quitLevel.SetActive(false);
        deadText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
