using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        MovePlayerRelativeToCamera();
    }
    
    void MovePlayerRelativeToCamera()
    {
        //Get Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        //Get Camera Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //Create direction-relative-input vectors
        Vector3 forwardRelativeVerticalInput = (playerVerticalInput * forward) * speed/100;
        Vector3 rightRelativeHorizontalInput = (playerHorizontalInput * forward) * speed/100;

        //Create and apply camera relative movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        this.transform.Translate(cameraRelativeMovement, Space.World);
    }
}
//https://www.youtube.com/watch?v=7kGCrq1cJew