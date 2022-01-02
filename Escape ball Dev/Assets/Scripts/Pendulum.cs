using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody rb;
    private float force = 5f;

    bool pushLeft = true;
    bool pushRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
      if (rb.velocity.x < 0 && pushLeft)
        {
            pushRight = true;
            rb.AddForce(Vector3.left * force, ForceMode.VelocityChange);
            pushLeft = false;
        }

      if (rb.velocity.x > 0 && pushRight)
        {
            pushRight = false;            
            rb.AddForce(Vector3.right * force, ForceMode.VelocityChange);
            pushLeft = true;
        }

    }
}
