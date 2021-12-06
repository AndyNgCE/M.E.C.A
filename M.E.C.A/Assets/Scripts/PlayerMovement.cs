using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int flares = 0;
    public GameObject myPrefab;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private SpriteRenderer flipper;
    private GameObject playerObj = null;

    PositionSaver playerPosData;
    private void Awake()
    {
        Debug.Log("AWAKE");
        playerPosData = FindObjectOfType<PositionSaver>();
        playerPosData.PlayerPosLoad();
    }

   /* GlobalControl playerHPData;
 private void Awake()
 {
     playerPosData = FindObjectOfType<GlobalControl>();
     GlobalControl.PlayerPosLoad();
 }*/

    Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        flipper = GetComponent<SpriteRenderer>();
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            flipper.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            flipper.flipX = true;
        }
        if (Input.GetKeyDown("e"))
        {
           GameObject marker = Instantiate(myPrefab) as GameObject;
            marker.transform.position = playerObj.transform.position;
           flares++;
        }
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
