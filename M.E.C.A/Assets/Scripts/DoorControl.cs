using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    Key MC;
    public Sprite newSprite;
    public Collider2D Collider;
    void Start()
    {
        MC = FindObjectOfType<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MC.door1 == true)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
