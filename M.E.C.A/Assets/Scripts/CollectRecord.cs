using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRecord : MonoBehaviour
{
PositionSaver playerPosData;


    // [SerializeField]
    GameObject indicator;
    private Kill knockOut;
    private List<int> tagline;

    [SerializeField]
    int ID;

    void Start()
    {
        indicator = GameObject.Find("Reaper");
        knockOut = indicator.GetComponent<Kill>();
        tagline = knockOut.GetList();
    }

    void CheckUp()
    {
        if (!tagline.Contains(ID))
        {
            tagline.Add(ID);
            Debug.Log("ADD " + ID);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Triggered by Player");
            CheckUp();
        }
    }
}
