using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private SpriteRenderer flipper;
    public Transform[] moveSpot;
    private int randomSpot;
    Vector2 posLastFrame;
    Vector2 posThisFrame;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        flipper = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);
       
        posLastFrame = posThisFrame;
        posThisFrame = transform.position;

        if (posThisFrame.x < posLastFrame.x)
        {
            flipper.flipX = false;
        }
        else if (posThisFrame.x > posLastFrame.x)
        {
            flipper.flipX = true;
        }

        if(Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
