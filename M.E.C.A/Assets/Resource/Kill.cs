using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public int pacMan = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
