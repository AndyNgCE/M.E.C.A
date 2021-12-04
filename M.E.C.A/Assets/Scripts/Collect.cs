using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    Count total;
    void Start()
    {
        total = FindObjectOfType<Count>();
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
