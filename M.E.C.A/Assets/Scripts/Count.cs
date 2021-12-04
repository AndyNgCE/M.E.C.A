using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    [SerializeField]
   public int collected = 0;

    void Start()
    {
        collected = PlayerPrefs.GetInt("lamp");
    }

   public void AddtoTotal()
    {
        collected++;
    }

    public void CollectSave()
    {
        PlayerPrefs.SetInt("lamp", collected);
    }

    public int Inventory()
    {
        return collected;
    }

}
