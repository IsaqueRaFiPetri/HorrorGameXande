using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Transform foot;
    bool groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = Physics.OverlapSphere(foot.position, 0.05f/*, foot.position*/);
    }
}
