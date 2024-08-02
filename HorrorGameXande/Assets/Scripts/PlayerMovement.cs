using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float forwardSpeed;
    public float strafeSpeed;
    bool isGrounded;
    Vector3 vertical;

    public Transform foot;
    public Collider[] collisions;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        collisions = Physics.OverlapSphere(foot.position, 0.5f);
        isGrounded = (collisions.Length > 0);
        Controls();

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(foot.position, 0.5f);
    }
    void Controls()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");
        Cursor.visible = true;
        Vector3 forward = forwardInput * forwardSpeed * transform.forward;
        Vector3 strafe = strafeInput * strafeSpeed * transform.right;
        if (isGrounded)
        {
           // vertical = Vector3.zero;
        }
        else
        {
            //vertical = Vector3.down * 10;
        }
        //vertical = Vector3.down * 10;
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        Vector3 finalVelocity = forward + strafe + vertical;
        controller.Move(finalVelocity * Time.deltaTime);
    }
}

//https://www.youtube.com/watch?v=7kGCrq1cJew