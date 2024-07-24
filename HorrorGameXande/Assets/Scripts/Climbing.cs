using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody body;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;

    private bool isClimbing;

    [Header("Detection")]
    public float detectionLenght;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;

    private void Update()
    {
        WallCheck();
        StateMachine();

        if (isClimbing) ClimbingMovement();
    }

    private void StateMachine()
    {
        // State 1 - Climbing
        if(wallFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {
            if(!isClimbing && climbTimer > 0 ) StartClimbing();

            // timer
            if(climbTimer >0) climbTimer -= Time.deltaTime;
            if(climbTimer < 0) StopClimbing();
        }
        //State 3 - None
        else
        {
            if (isClimbing) StopClimbing();

        }
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLenght, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        if (!isClimbing)
        {
            climbTimer = maxClimbTime;
        }
    }

    private void StartClimbing()
    {
        isClimbing = true;
    }

    private void ClimbingMovement()
    {
        body.velocity = new Vector3(body.velocity.x, climbSpeed, body.velocity.z);
    }

    private void StopClimbing()
    {
       isClimbing = false;
    }
}
//https://www.youtube.com/watch?v=tAJLiOEfbQg