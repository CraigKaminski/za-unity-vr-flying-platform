using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // destinations / targets
    public Transform[] targets;

    // speed
    public float speed = 1;

    // bool that sets whether we are moving or not
    bool isMoving = false;

    // next destination index
    int nextIndex;

    // Use this for initialization
    void Start()
    {
        // set the player to the first target
        transform.position = targets[0].position;

        // next destination is 1
        nextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for input
        HandleInput();

        // Move our platform
        HandleMovement();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isMoving = !isMoving;
        }
    }

    // take care of movement
    private void HandleMovement()
    {
        if (isMoving)
        {
            // calculate the distance from target
            float distance = Vector3.Distance(transform.position, targets[nextIndex].position);

            // have we arrived?
            if (distance > 0)
            {
                // calculate how much we need to move (step) d = v * t
                float step = speed * Time.deltaTime;

                // move by that step
                transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
            }
            else
            {
                if (nextIndex == targets.Length - 1)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex++;
                }

                isMoving = false;
            }
        }
    }
}
