using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public static List<int> grave = new List<int>();
    public static Kill removal;

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

    public List<int> GetList()
    {
        return grave;
    }
}
