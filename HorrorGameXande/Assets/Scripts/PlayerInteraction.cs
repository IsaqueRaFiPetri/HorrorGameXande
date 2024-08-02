using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance;
    public UnityEvent OnInteractionEffected;
    Transform cam;
    public float handDistance = 3;

    void Start()
    {
        Instance = this;
        cam = Camera.main.transform;
    }

    public void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.position, cam.forward * handDistance, Color.blue);
        if (Physics.Raycast(cam.position, cam.forward, out hit, handDistance))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
                //print(hit.collider.name);
            }
        }
    }
}