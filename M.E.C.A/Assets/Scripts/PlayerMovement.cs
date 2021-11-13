using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    /*PositionSaver playerPosData;
    private void Awake()
    {
        playerPosData = FindObjectOfType<PositionSaver>();
        playerPosData.PlayerPosLoad();
    }*/

    /*GlobalControl playerHPData;
 private void Awake()
 {
     playerPosData = FindObjectOfType<GlobalControl>();
     GlobalControl.PlayerPosLoad();
 }*/

    Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }


    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
