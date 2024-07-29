using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Transform foot;
    Rigidbody rb;
    public Collider[] collisions;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.useGravity = !(Physics.OverlapSphere(foot.position, 0.5f).Length > 0);
        collisions = Physics.OverlapSphere(foot.position, 0.02f);
        rb.useGravity = !(collisions.Length > 0);

    }
}
