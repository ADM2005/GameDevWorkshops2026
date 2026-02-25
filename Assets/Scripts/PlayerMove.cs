using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 10f;
    public float acceleration = 5f;
    Rigidbody rb;

    Vector2 input;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector3 targetVelocity = new Vector3(input.x,0f,input.y).normalized * speed;
        
        velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 normal = other.contacts[0].normal;
        // Get component of velocity going towards normal
        velocity = Vector3.Reflect(velocity,normal) * 0.5f;
    }


}
