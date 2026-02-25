using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 5f;
    public float jumpForce = 20f;

    Rigidbody rb;
    Vector2 input;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector3 targetVelocity = new Vector3(input.x, 0f, input.y).normalized * speed;
        velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);

        // NEW: Jump when grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        // NOTE: We now preserve the rigidbody's Y velocity so gravity still applies
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 normal = other.contacts[0].normal;

        // NEW: Check if we've landed on something roughly flat
        if (Vector3.Dot(normal, Vector3.up) > 0.5f)
        {
            isGrounded = true;
        }

    }
}
