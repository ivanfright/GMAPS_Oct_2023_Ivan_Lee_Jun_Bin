using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Add force to the Rigidbody
        rb.AddForce(force);
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

