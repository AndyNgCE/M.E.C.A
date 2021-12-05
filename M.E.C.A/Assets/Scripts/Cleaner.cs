using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
   // [SerializeField]
    GameObject soul;
    private Kill crosshair;
    private List<int> border;

    [SerializeField]
    int ID;

    

    void Awake()
    {
        soul = GameObject.Find("Reaper");
        crosshair = soul.GetComponent<Kill>();
        border = crosshair.GetList();
        CheckUp();
    }

    void CheckUp()
    {
        foreach (var x in border)
        {
            Debug.Log("In Grave: " + x.ToString());
        }
        if (border.Contains(ID))
        {
            Debug.Log("Cleaned " + ID);
            Destroy(this.gameObject);
        }
    }
}
