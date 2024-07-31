using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void MovePlayerRelativeToCamera()
    {
        //Get Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        //Get Camera Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        //Create direction-relative-input vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeHorizontalInput = playerHorizontalInput * forward;

        //Create and apply camera relative movement
        Vector3 camerarelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        this.transform.Translate(camerarelativeMovement, Space.World);
    }
}
//https://www.youtube.com/watch?v=7kGCrq1cJew