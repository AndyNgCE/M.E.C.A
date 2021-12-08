using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl3 : MonoBehaviour
{
    Key3 MC;
    public Sprite newSprite;
    public Collider2D Collider;
    void Start()
    {
        MC = FindObjectOfType<Key3>();
    }

    // Update is called once per frame
    void Update()
    {
        MC = FindObjectOfType<Key3>();
        if (MC == null)
        {
            return;
        }
        if (MC.door3 == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
