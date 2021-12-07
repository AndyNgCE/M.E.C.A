using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    GameObject counter;
    Count total;
    void Start()
    {
        counter = GameObject.Find("Reaper");
        total = counter.GetComponent<Count>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            total.AddtoTotal();
            Destroy(this.gameObject);
        }
    }
}
