using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    [SerializeField]
   public int collected = 0;
    public static Count removal;
    void Awake()
    {
        if (removal != null && removal != this)
        {
            Destroy(this.gameObject);
            return;
        }

        removal = this;
        DontDestroyOnLoad(this);
    }
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
