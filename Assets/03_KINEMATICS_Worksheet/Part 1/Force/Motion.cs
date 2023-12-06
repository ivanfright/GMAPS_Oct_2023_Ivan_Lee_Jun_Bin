using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        //Time past
        float dt = Time.deltaTime;

        //Move by time
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        // Update the position of the object based on its velocity
        transform.Translate(new Vector3(dx, dy, dz));
    }
}