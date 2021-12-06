using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl2 : MonoBehaviour
{
    Key2 MC;
    public Sprite newSprite;
    public Collider2D Collider;
    void Start()
    {
        MC = FindObjectOfType<Key2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.door2 == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
